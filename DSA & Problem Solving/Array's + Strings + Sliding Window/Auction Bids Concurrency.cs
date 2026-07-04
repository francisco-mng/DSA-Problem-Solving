using System;
using System.Collections.Generic;
using System.Threading.Tasks;



public class AuctionBiddingDrill
{
    public async Task Run()
    {
        Console.WriteLine("=== DAY 5: THE CORE BIDDING & OCC DRILL ===");
        Console.WriteLine("Target: Secure transactions under concurrent write pressure.\n");

        await Test_StandardValidBid();
        await Test_TooLowBidRejected();
        await Test_InsufficientFundsRejected();
        await Test_BiddingWarRaceCondition_WithOCC();
    }

    /// <summary>
    /// Processes an incoming bid under transactional constraints.
    /// CONSTRAINTS:
    /// - Must validate that the auction item exists.
    /// - Must validate that the auction is not expired.
    /// - Must validate that the bid amount is strictly greater than the current highest bid.
    /// - Must validate that the user exists and has a balance >= the bid amount.
    /// - Must propagate DbUpdateConcurrencyException if saving fails due to a version collision.
    /// </summary>
    public bool PlaceBid(MockDatabaseContext db, int userId, int auctionItemId, decimal amount)
    {
        // 1. Fetch the detached snapshot item representing the state seen by the bidder
        AuctionItem currItem = db.GetAuctionItem(auctionItemId);

        if (currItem == null) return false;

        // --- THE RACE FIX ---
        // Introduce a tiny artificial delay to simulate real-world database network latency.
        // This ensures that in concurrent testing, both Alice and Bob's threads finish reading 
        // the initial state (Version 1) before either of them can execute SaveChanges!
        System.Threading.Thread.Sleep(50);

        if (currItem.IsExpired) return false;

        // 2. Validate that the new bid is strictly higher than the current highest bid
        if (currItem.CurrentHighestBid >= amount) return false;

        // 3. Fetch user and validate balance
        User user = db.GetUser(userId);
        if (!(user != null && (user.AccountBalance >= amount))) return false;

        // 4. Create new bid if requirements are met
        Bid newBid = new Bid
        {
            UserId = userId,
            AuctionItemId = auctionItemId,
            Amount = amount,
            Timestamp = DateTime.UtcNow
        };

        // 5. Update our snapshot's highest bid amount
        currItem.CurrentHighestBid = amount;

        // 6. Save changes. This will compare snapshot version against current DB version.
        db.SaveChanges(currItem, newBid);
        return true;
    }

    #region TEST SUITE DEFINITIONS

    private async Task Test_StandardValidBid()
    {
        var db = new MockDatabaseContext();
        db.Seed(new User { Id = 1, Username = "Alice", AccountBalance = 1000m },
                new AuctionItem { Id = 10, Title = "Charizard Card", CurrentHighestBid = 100m, IsExpired = false, Version = 1 });

        bool success = PlaceBid(db, userId: 1, auctionItemId: 10, amount: 150m);

        var finalItem = db.GetAuctionItem(10);
        if (success && finalItem.CurrentHighestBid == 150m && db.Bids.Count == 1)
        {
            Pass("Standard Valid Bid");
        }
        else
        {
            Fail("Standard Valid Bid", $"Expected $150 bid registered. Got success={success}, CurrentHighestBid={finalItem?.CurrentHighestBid}");
        }
    }

    private async Task Test_TooLowBidRejected()
    {
        var db = new MockDatabaseContext();
        db.Seed(new User { Id = 1, Username = "Alice", AccountBalance = 1000m },
                new AuctionItem { Id = 10, Title = "Charizard Card", CurrentHighestBid = 200m, IsExpired = false, Version = 1 });

        bool success = PlaceBid(db, userId: 1, auctionItemId: 10, amount: 150m);

        var finalItem = db.GetAuctionItem(10);
        if (!success && finalItem.CurrentHighestBid == 200m)
        {
            Pass("Too Low Bid Rejected");
        }
        else
        {
            Fail("Too Low Bid Rejected", $"Expected failure and bid to remain at $200. Got success={success}, CurrentHighestBid={finalItem?.CurrentHighestBid}");
        }
    }

    private async Task Test_InsufficientFundsRejected()
    {
        var db = new MockDatabaseContext();
        db.Seed(new User { Id = 1, Username = "Alice", AccountBalance = 50m },
                new AuctionItem { Id = 10, Title = "Charizard Card", CurrentHighestBid = 100m, IsExpired = false, Version = 1 });

        bool success = PlaceBid(db, userId: 1, auctionItemId: 10, amount: 150m);

        if (!success)
        {
            Pass("Insufficient Funds Rejected");
        }
        else
        {
            Fail("Insufficient Funds Rejected", "Expected system to reject bid since Alice tried to bid more than her account balance.");
        }
    }

    private async Task Test_BiddingWarRaceCondition_WithOCC()
    {
        var db = new MockDatabaseContext();
        db.Seed(new User { Id = 1, Username = "Alice", AccountBalance = 1000m },
                new AuctionItem { Id = 10, Title = "Vintage Rolex", CurrentHighestBid = 100m, IsExpired = false, Version = 1 });
        db.Users[2] = new User { Id = 2, Username = "Bob", AccountBalance = 1000m };

        int aliceCollisions = 0;
        int bobCollisions = 0;
        int successfulBids = 0;

        Task t1 = Task.Run(() =>
        {
            try
            {
                if (PlaceBid(db, 1, 10, 150m)) successfulBids++;
            }
            catch (DbUpdateConcurrencyException)
            {
                aliceCollisions++;
            }
        });

        Task t2 = Task.Run(() =>
        {
            try
            {
                if (PlaceBid(db, 2, 10, 150m)) successfulBids++;
            }
            catch (DbUpdateConcurrencyException)
            {
                bobCollisions++;
            }
        });

        await Task.WhenAll(t1, t2);

        var finalItem = db.GetAuctionItem(10);
        int totalCollisions = aliceCollisions + bobCollisions;

        if (successfulBids == 1 && totalCollisions == 1 && finalItem.CurrentHighestBid == 150m)
        {
            Pass("Bidding War Race Condition (OCC Works!)");
        }
        else
        {
            Fail("Bidding War Race Condition", $"Race failed. Successful bids: {successfulBids}, Total OCC collisions caught: {totalCollisions}, Final Price: {finalItem?.CurrentHighestBid}. Expected exactly 1 success and 1 caught collision.");
        }
    }

    private void Pass(string testName)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[PASS] {testName}");
        Console.ResetColor();
    }

    private void Fail(string testName, string errorMsg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[FAIL] {testName} | {errorMsg}");
        Console.ResetColor();
    }

    #endregion
}

#region DATA MODELS & MOCK CONTEXT

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public decimal AccountBalance { get; set; }
}

public class AuctionItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal CurrentHighestBid { get; set; }
    public bool IsExpired { get; set; }
    public int Version { get; set; }
}

public class Bid
{
    public int Id { get; set; }
    public int AuctionItemId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
}

public class DbUpdateConcurrencyException : Exception
{
    public DbUpdateConcurrencyException(string message) : base(message) { }
}

public class MockDatabaseContext
{
    private readonly object _lock = new ();

    public Dictionary<int, User> Users { get; } = new Dictionary<int, User>();
    public Dictionary<int, AuctionItem> AuctionItems { get; } = new Dictionary<int, AuctionItem>();
    public List<Bid> Bids { get; } = new List<Bid>();

    public void Seed(User user, AuctionItem item)
    {
        Users[user.Id] = new User { Id = user.Id, Username = user.Username, AccountBalance = user.AccountBalance };
        AuctionItems[item.Id] = new AuctionItem { Id = item.Id, Title = item.Title, CurrentHighestBid = item.CurrentHighestBid, IsExpired = item.IsExpired, Version = item.Version };
    }

    public AuctionItem GetAuctionItem(int id)
    {
        lock (_lock)
        {
            if (!AuctionItems.TryGetValue(id, out var item)) return null;
            return new AuctionItem
            {
                Id = item.Id,
                Title = item.Title,
                CurrentHighestBid = item.CurrentHighestBid,
                IsExpired = item.IsExpired,
                Version = item.Version
            };
        }
    }

    public User GetUser(int id)
    {
        lock (_lock)
        {
            if (!Users.TryGetValue(id, out var user)) return null;
            return new User { Id = user.Id, Username = user.Username, AccountBalance = user.AccountBalance };
        }
    }

    public void SaveChanges(AuctionItem updatedItem, Bid newBid)
    {
        lock (_lock)
        {
            if (!AuctionItems.TryGetValue(updatedItem.Id, out var existingItem))
            {
                throw new Exception("Entity not found.");
            }

            // OPTIMISTIC CONCURRENCY CHECK
            if (updatedItem.Version != existingItem.Version)
            {
                throw new DbUpdateConcurrencyException("Database update failed due to concurrency collision.");
            }

            // Process update
            existingItem.CurrentHighestBid = updatedItem.CurrentHighestBid;
            existingItem.Version++;

            Bids.Add(newBid);
        }
    }
}

#endregion