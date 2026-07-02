/* ///*

////List<string> playlist = [];

////playlist.Add("This one");
////playlist.Add("Ahis two");
////playlist.Add("0his three");
////playlist.Add("1his fouraaaa");

////playlist.Insert(1, "Francisco");

////playlist.Remove("This four");

////playlist.Sort();

////foreach (var a in playlist)
////    Console.WriteLine(a);
//

///*
//int[] IDs = { 101, 102, 101, 104, 102, 105, 101 };

//HashSet<int> s = [];

//foreach (var num in IDs)
//{
//    s.Add(num);
//}

////HashSet stores unique values ;)
////Retrieval time is O(1)

//foreach (var num in s)
//    Console.WriteLine(num);
//*/

////Dictionary<string, int> inventory = [];

////inventory.Add("Laptops", 5);
////inventory.Add("Monitors", 12);

////if (inventory.ContainsKey("Laptops"))
////    inventory["Laptops"] = inventory["Laptops"] + 1;


////foreach( var s in inventory)
////{
////    Console.WriteLine($"Item : {s.Key}, Quantity: {s.Value}");
////}


/*

////Minimum characters to add...

//// Keep incrementing index on the reverse as well as the main string. 
//// Once the substring and its reverse match, that's the min number of characters to add to make the word a palindome.

//using System.Collections.Specialized;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.Design;
//using System.Runtime.InteropServices;
//using System.Security;

//int Minimum_Characters_To_Add(string s)
//{

//    char[] p = s.ToCharArray();
//    Array.Reverse(p);

//    string rev = new(p);

//    Console.WriteLine(rev);

//    for(int k = 0; k < s.Length; k++)
//    {
//        if (s.Substring(k) != rev.Substring(0, rev.Length - k)) 
//        {
//            continue;
//        }
//        else
//        {
//            return k;
//        }
//    }
//    return 0;
//}

////string value = "banana";

////Console.WriteLine($"This is the min for {value}: {Minimum_Characters_To_Add(value)}");



////Unique Sliding Window (Leetcode could be a good investment afterall)

//int longest_substring_without_repeating_characters(string s)
//{
//    int i = 0; // Left pointer (Evictor)
//    int j = 0; // Right pointer (Explorer)
//    int max = 0;
//    HashSet<char> currentSub = new HashSet<char>();

//    // We loop until the Explorer finishes checking the whole word
//    while (j < s.Length)
//    {
//        // 1. Ask the bag: "Do you already have the letter at j?"
//        if (!currentSub.Contains(s[j]))
//        {
//            // SAFE! It is unique.
//            currentSub.Add(s[j]);                    // Put it in the bag

//            // Math trick: The length is just the number of items in the bag
//            max = currentSub.Count > max ? currentSub.Count : max;

//            j++;                                     // Explorer steps forward
//        }
//        else
//        {
//            // COLLISION! The letter is already in the bag.
//            currentSub.Remove(s[i]);                 // Take the left-most letter OUT of the bag
//            i++;                                     // Evictor steps forward

//            // CRITICAL: We DO NOT move 'j' here. 
//            // 'j' just waits until the collision is cleared on the next loop.
//        }
//    }

//    return max;
//}

//Console.WriteLine(longest_substring_without_repeating_characters("pwwkew"));


////string s = "Blakamanya";
////Console.WriteLine(s[0..1]);


///*
// * LESS OPTIMAL SOLUTION
// * 
//int longest_substring_without_repeating_characters(string s)
//{

//    int i = 0;
//    int j = 0;
//    //Default value of max = 1 or zero if string is empty
//    //I can use logic that mimics hashset implicitly
//    int max = s.Length > 0 ? 1 : 0;
//    HashSet<char> currentSub = [];

//    //So instead of building the substring, keep count of how many elements the substring consists of?
//    while (i < s.Length)
//    {
//        currentSub = s[i..((j + 1))].ToHashSet();

//        bool can_move_right = false;
//        bool can_move_left = false;

//        can_move_right = (i == j || s[i] != s[j] && i != j) && (j != s.Length - 1);
//        can_move_left = (i != j && s[i] == s[j]) || (j == s.Length - 1);

//        Console.WriteLine($"i:{i} j{j}, s:{s} sub:{currentSub} max:{max}\n");
//        Console.WriteLine($"move_right? {can_move_right}\ni == j || s[i] != s[j] && i!=j) && (j != s.Length -1)   \n=> ({i == j} ||{s[i] != s[j]} && {i != j}) && ({j != s.Length - 1})\n");
//        Console.WriteLine($"move_left? {can_move_left}\nj == s.Length - 1 || i!=j && s[i] == s[j]  \n=> {j == s.Length - 1} || {i != j} && {s[i] == s[j]}\n\n\n\n");

//        if (can_move_right)
//        {

//            if (j < s.Length - 1)
//            {
//                j++;
//                currentSub = s[i..((j + 1))];
//                if (s[i] != s[j]) max = currentSub.Count >= max ? currentSub.Count : max;
//            }


//        }
//        else if (can_move_left)
//        {
//            i++;
//        }
//    }

//    return max;
//}

//*/


using DSA___Problem_Solving;
using System.Net.Http.Headers;
using System.Security;

///<summary>
/// You need to uncomment only one object initialization to run any test case ;)
/// </summary>


//MaxSumFixedWindowSize  p = new MaxSumFixedWindowSize();
//var s = new Elastic_VIP_Section();
//var s = new Bouncer();
//var s = new Longest_Ones();
//var s = new LongestNonRepeatingSubstring();
//var s = new Anagrams__1();


var s = new Next_Lexicographical_Permutation_of_Array();
s.Run();


int[] n = new int[1];
int[] p = n; n[0] = 1;

Console.Write($"Reference types : n[0] : {n[0]} p[0]: {p[0]}");