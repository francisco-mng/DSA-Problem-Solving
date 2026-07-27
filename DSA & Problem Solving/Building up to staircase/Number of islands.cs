using System;
using System.Collections.Generic;
using System.Text;

namespace DSA___Problem_Solving.Building_up_to_staircase
{

public class ArchipelagoTester
    {
        public static void Main()
        {
            Console.WriteLine("=== DAY 4: STEPPING STONE 5 ===");
            Console.WriteLine("Problem: Number of Islands (The Archipelago)\n");

            char[][] grid1 = new char[][]
            {
            new char[] {'1','1','1','1','0'},
            new char[] {'1','1','0','1','0'},
            new char[] {'1','1','0','0','0'},
            new char[] {'0','0','0','0','0'}
            };

            char[][] grid2 = new char[][]
            {
            new char[] {'1','1','0','0','0'},
            new char[] {'1','1','0','0','0'},
            new char[] {'0','0','1','0','0'},
            new char[] {'0','0','0','1','1'}
            };

            char[][] grid3 = new char[][]
            {
            new char[] {'1'}
            };

            char[][] grid4 = new char[][]
            {
            new char[] {'0'}
            };

            RunTest("Test Case 1 (Single Massive Island)", grid1, 1);
            RunTest("Test Case 2 (Three Distinct Islands)", grid2, 3);
            RunTest("Test Case 3 (Single Cell - Land)", grid3, 1);
            RunTest("Test Case 4 (Single Cell - Water)", grid4, 0);

            Console.WriteLine("\nTesting complete. The compiler does not lie.");
        }

        public static void RunTest(string testName, char[][] grid, int expected)
        {
            Solution sol = new Solution();
            int result = sol.NumIslands(grid);

            if (result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[PASS] {testName} | Expected: {expected}, Got: {result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] {testName} | Expected: {expected}, Got: {result}");
            }
            Console.ResetColor();
        }
    }

    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            // The Forge is yours. 
            // Remember: You have to keep track of the land you've already explored.
            int[][] region = new int[grid.Length][];
            for(int i = 0; i < region.Length; i++)
            {
                region[i] = new int[grid[i].Length];
            }

            //Now we have a grid we can mark and label ;)

            int r,      c;
                r = 0;  c = 0;

            int currCount = 0;

            for (r = 0; r < grid.Length; r++) { 
                for(c = 0; c < grid[r].Length; c++)
                {
                    //Mark surrounding region if val == '1'

                    if (grid[r][c] == '1')
                    {
                        MarkRegion(r, c, grid, region, currCount);
                    }
                }
            }

            return 0;
        }


        private void MarkRegion(int r, int c, char[][] grid, int[][] region, int currCount)
        {
            //Some condition to tell whether
            //or not the current 1 is marked
            //and is related with the other
            //elements in the region...


            //self
            region[r][c] = currCount;

            //left 
            if (c > 0) 
                region[r][c - 1] = grid[r][c - 1] == '1'? currCount : region[r][c - 1];

            //right
            if(c < region[0].Length - 1) 
                region[r][c + 1] = grid[r][c + 1] == '1'? currCount : grid[r][c + 1];

            //up
            if (r > 0) 
                region[r - 1][c] = grid[r - 1][c] == '1' ? currCount : grid[r - 1][c];

            //down
            if (r < region.Length - 1) region[r + 1][c] = region[r+1][c] == '1' ? currCount : region[r + 1][c];
        }
    }
}
