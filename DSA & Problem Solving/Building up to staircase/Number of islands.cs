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
            Solution2 sol = new Solution2();
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


    /// <summary>
    /// PROBLEM WITH CURRENT IMPLEMENTATION -> Shortsighted lookahead algorithm.
    /// /                                   -> Opt in to do DFS to find all the neighbors recursively...
    ///                                     -> So for every cell that is a '1', recursively find all the other 1's
    /// </summary>
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            // The Forge is yours. 
            // Remember: You have to keep track of the land you've already explored.
            int[][] region = new int[grid.Length][];
            for (int i = 0; i < region.Length; i++)
            {
                region[i] = new int[grid[i].Length];
            }

            //Now we have a grid we can mark and label ;)

            int r, c;
            r = 0; c = 0;

            int currCount = 0;

            for (r = 0; r < grid.Length; r++)
            {
                for (c = 0; c < grid[r].Length; c++)
                {
                    //Mark surrounding region if val == '1'

                    if (grid[r][c] == '1')
                    {
                        //Start current count at 1
                        //currCount = currCount == 0 ? 1 : currCount;
                        MarkRegion(r, c, grid, region, ref currCount);
                    }
                }
            }

            return currCount;
        }


        private void MarkRegion(int r, int c, char[][] grid, int[][] region, ref int currCount)
        {
            //Some condition to tell whether
            //or not the current 1 is marked
            //and is related with the other
            //elements in the region...

            if (region[r][c] == 0)
            {
                //Not marked ;)
                //Check for any neighbors && take that value of the neighbors if found
                int res = findNeighborRegion(region, r, c);
                currCount = res != -1 ? res : currCount + 1;
            }

            //self
            region[r][c] = currCount;

            //left 
            if (c > 0)
                region[r][c - 1] = grid[r][c - 1] == '1' ? currCount : region[r][c - 1];

            //right
            if (c < region[0].Length - 1)
                region[r][c + 1] = grid[r][c + 1] == '1' ? currCount : region[r][c + 1];

            //up
            if (r > 0)
                region[r - 1][c] = grid[r - 1][c] == '1' ? currCount : region[r - 1][c];

            //down
            if (r < region.Length - 1) region[r + 1][c] = grid[r + 1][c] == '1' ? currCount : region[r + 1][c];
        }

        int findNeighborRegion(int[][] region, int r, int c)
        {
            int val;
            //Up
            if (r > 0)
            {
                if (region[r - 1][c] != 0)
                {
                    val = region[r - 1][c];
                    return val;
                }
            }

            //Down
            if (r < region.Length - 1)
            {
                if (region[r + 1][c] != 0)
                {
                    val = region[r + 1][c];
                    return val;
                }
            }


            //Left
            if (c > 0)
            {
                if (region[r][c - 1] != 0)
                {
                    val = region[r][c - 1];
                    return val;
                }
            }


            //Right
            if (c < region[0].Length - 1)
            {
                if (region[r][c + 1] != 0)
                {
                    val = region[r - 1][c + 1];
                    return val;
                }
            }
            val = -1;
            return val;
        }
    }


    public class Solution2
    {
        public int NumIslands(char[][] grid)
        {
            // Safety check for empty grids
            if (grid == null || grid.Length == 0) return 0;

            int numIslands = 0;

            // Sweep the entire grid
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    // When we find an unvisited piece of land
                    if (grid[r][c] == '1')
                    {
                        numIslands++; // Count this new island
                        SinkIsland(grid, r, c); // Trigger DFS to clear the whole island
                    }
                }
            }

            return numIslands;
        }

        private void SinkIsland(char[][] grid, int r, int c)
        {
            // 1. BASE CASES: When to stop recursion
            // If we step out of bounds OR if we hit water ('0'), stop.
            if (r < 0 || r >= grid.Length ||
                c < 0 || c >= grid[0].Length ||
                grid[r][c] == '0')
            {
                return;
            }

            // 2. ACTION: Mark this land as visited by turning it into water
            grid[r][c] = '0';

            // 3. RECURSION: Check all 4 adjacent directions
            SinkIsland(grid, r + 1, c); // Down
            SinkIsland(grid, r - 1, c); // Up
            SinkIsland(grid, r, c + 1); // Right
            SinkIsland(grid, r, c - 1); // Left
        }
    }

}