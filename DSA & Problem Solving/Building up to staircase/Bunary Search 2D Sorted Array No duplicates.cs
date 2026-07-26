using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DSA___Problem_Solving.Building_up_to_staircase
{
    internal class Bunary_Search_2D_Sorted_Array_No_duplicates
    {

        public bool Search2D(int[][] arr, int target)
        {
           

            if (arr.Length == 0 || arr[0].Length == 0) return false;

            int rows = arr.Length;
            int cols = arr[0].Length;

            //Setting 1D mapping of the 2D array

            int left = 0;
            int right = rows * cols - 1;

            while(left <= right)
            {
                int mid = (right - left) / 2;
                int midValue = arr[mid / cols][mid % cols];

                if (midValue == target)
                {
                    return true;
                }
                else if(midValue < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }

            }
            return false;

        }

        private bool IsDuplicateVisit(int[] arr, int row) {

            //Return true if row is not a duplicate
            return arr[row] != 1;
        }
    }
}
