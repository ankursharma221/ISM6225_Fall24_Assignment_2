using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        /* Question 1: Find Missing Numbers in Array
           Logic: The problem is solved in a clear sequence of steps: first, filling the dictionary with present numbers, 
           then iterating from 1 to n to find missing numbers, and returning the newlist. 
           Thus, efficiently checking for missing numbers in O(n) time by using a dictionary as a lookup table.

           Time Complexity: O(n)

           Self Reflection: In this problem, I learned how to map a Python-style solution to C# syntax. 
           The process of using dictionaries and lists in C# is similar to Python which I covered in previous semester. It was fun to do it in C#.
        */
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Step 1: Initialize a list for missing numbers and a dictionary to track occurrences
				List<int> newList = new List<int>(); // To store missing numbers
                Dictionary<int,int> newDict = new Dictionary<int,int>(); // To track numbers in the array

                // Step 2: Populate the dictionary with the array elements
                for(int i = 0; i < nums.Length; i++){
					if (!newDict.ContainsKey(nums[i])){
						newDict.Add(nums[i],1); // Add the number as a key if it's not already present
					}
				}
                // Step 3: Find the missing numbers from 1 to n
				for(int i = 1; i<=nums.Length; i++){
					if(!newDict.ContainsKey(i)){
						newList.Add(i);
					}
				}
                // Step 4: Return the list of missing numbers
                return newList; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Question 2: Sort Array by Parity
        Logic: The logic is structured in an organized way, dividing the even and odd numbers into separate lists
         and merging them after categorization which ensures  ensures that all even numbers appear before odd numbers
         without reordering even or odd numbers relative to each other.
        
        Time Complexity: O(n)

        Self Reflection: I understand using lists in C# for dynamic collection operations like filtering evens and odds. 
        I like how easy it was to split, concatenate, and return arrays.
        */
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Step 1: Initialize two lists to store even and odd numbers separately
                    List<int> evens = new List<int>();
                    List<int> odds = new List<int>();

                // Step 2: Traverse the array and categorize numbers into evens and odds
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] % 2 == 0)
                        {
                            evens.Add(nums[i]);  // Add to evens if divisible by 2
                        }
                        else
                        {
                            odds.Add(nums[i]);  // Add to odds if not divisible by 2
                        }
                    }

                // Step 3: Concatenate the even numbers followed by odd numbers
                    evens.AddRange(odds);  // Merge the two lists

                // Step 4: Return the result as an array
                    return evens.ToArray();  // Convert list to array and return
                        
                    }
            catch (Exception)
            {
                throw;
            }
        }

        /*  Question 3: Two Sum
            This logic is to solve the Two Sum problem efficiently by using a dictionary to enable quick lookups, 
            allowing the solution to handle large inputs within reasonable time limits.

            Time Complexity: O(n)

            Self Reflection: Implementing this solution helped reinforce my understanding of how hash-based data structures like dictionaries can significantly optimize search operations. 


        */
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                List<int> resList = new List<int>(); // Initialize a list to store the result indices
                Dictionary<int, int> newDict = new Dictionary<int, int>(); // Dictionary to store numbers and their indices

            // Traverse the input array
               for (int i = 0; i < nums.Length; i++)
                     {
                            // Check if the complement (target - current number) is already in the dictionary
                        if (!newDict.ContainsKey(target - nums[i]))
                        {
                            newDict.Add(nums[i], i); // If not, add the current number and its index to the dictionary
                        }
                        else
                        {
                            // If the complement is found, add the indices to the result list
                            resList.Add(newDict[target - nums[i]]); // Index of the complement
                            resList.Add(i); // Current index
                        return resList.ToArray(); // Return the result as an array
                        }
                     }

                // Return the result list as an array (will be empty if no solution is found)
                return resList.ToArray();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        /* 
        Logic: The logisc is to sort the input array, which enables easy access to the largest and smallest values.
         After sorting, two potential products are calculated: one from the three largest numbers and another 
         from the two smallest numbers (which could be negative) multiplied by the largest number. 
         The maximum of these two products is returned as the result. This approach ensures that all scenarios are considered,
         particularly those involving negative numbers, allowing for an efficient determination of the maximum product.
        
        Time Complexity: O(n)

        Self Reflection: Implementing this solution highlighted the importance of considering both the largest and smallest values in a list, 
        especially when dealing with negative numbers. It reinforced my understanding of how sorting can simplify the problem and lead to an efficient solution.
        */
        public static int MaximumProduct(int[] nums)
        {
            try
            {// Step 1: Sort the array
                Array.Sort(nums); // Sorts the array in non-decreasing order

                // Step 2: Calculate the maximum product of the last three numbers
                int product1 = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];

                // Step 3: Calculate the product of the first two (potentially negative) and the last number
                int product2 = nums[0] * nums[1] * nums[nums.Length - 1];

                // Step 4: Return the maximum of the two products
                return Math.Max(product1, product2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        /*
        Logic: The Decimal to Binary Conversion function converts a given decimal number to its binary 
        representation by repeatedly dividing the number by 2 and prepending the remainder (either 0 or 1) 
        to the resulting binary string. If the input number is 0, the function returns "0" directly. 
        The process continues until the decimal number is reduced to 0. Finally, the constructed binary string is 
        returned as the result.

        Time Complexity: O(logn)

        Self Reflection: Writing this function in C# familiarized me with string manipulation and control flow, particularly the use of while loops and string concatenation.
        */
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                    if (decimalNumber == 0) return "0"; // Handle the case for 0 directly

                    string binaryString = ""; // Initialize an empty string to build the binary representation

                    // Convert decimal to binary
                    while (decimalNumber > 0)
                    {
                        // Prepend the remainder (0 or 1) to the binary string
                        binaryString = (decimalNumber % 2) + binaryString;
                        decimalNumber /= 2; // Divide by 2 to process the next bit
                    }

                    return binaryString; // Return the final binary string
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        /*
        Logic: The Find Minimum in Rotated Sorted Array function utilizes a modified binary search approach to efficiently locate the minimum element in a rotated sorted array. 
        First, it checks if the array is not rotated (i.e., the first element is less than the last). 
        If true, it immediately returns the first element as the minimum. 
        If the array is rotated, the function enters a loop where it calculates the middle index. 
        If the middle element is greater than the rightmost element, it implies that the minimum must be in the right half of the array, so it adjusts the left pointer. 
        Otherwise, it moves the right pointer to the middle. The process continues until the left pointer meets the right pointer, at which point it points to the minimum element.

        Time Complexity: O(log n)

        Self Reflection:  Implementing this function deepened my understanding of binary search techniques and how they can be adapted for different scenarios, such as searching in a rotated sorted array.

        */


        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0; // Start index
                int right = nums.Length - 1; // End index

                // Handle case when array is not rotated (the first element is the minimum)
                if (nums[left] < nums[right])
                    return nums[left];

                while (left < right)
                {
                    int mid = left + (right - left) / 2; // Calculate the middle index

                    // If mid element is greater than rightmost element,
                    // the minimum must be in the right half
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1; // Move the left pointer to mid + 1
                    }
                    else
                    {
                        right = mid; // Move the right pointer to mid
                    }
                }

                return nums[left]; // The left pointer will point to the minimum element
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        /*
        Time Complexity: O(log n)

        Self Reflection: This exercise enhanced my understanding of number manipulation and how to check for palindromes efficiently without converting the number to a string.

        */
        public static bool IsPalindrome(int x)
        {
            try
            {   // A negative number is not a palindrome
                // Also, numbers that end with 0 and are not 0 are not palindromes
                if (x < 0 || (x % 10 == 0 && x != 0))
                    return false;

                int reversedHalf = 0; // Variable to store the reversed half of the number

                // Reverse the digits of the number
                while (x > reversedHalf)
                {
                    reversedHalf = reversedHalf * 10 + x % 10; // Build the reversed number
                    x /= 10; // Remove the last digit from x
                }

                // The number is a palindrome if it is equal to its reversed half
                // or if it is equal to the reversed half without the middle digit (for odd lengths)
                return x == reversedHalf || x == reversedHalf / 10;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        /*
        Logic: The below function iteratively computes the Fibonacci numbers up to n by summing the two previous numbers and updating the variables accordingly. The final result is the nth Fibonacci number.

        Time complexity: O(n)

        Self reflection: Implementing the Fibonacci function reinforced my understanding of the Fibonacci sequence and different approaches to compute it efficiently

        */
        public static int Fibonacci(int n)
        {
            try
            {
                // Base cases
                if (n <= 0) return 0; // Fibonacci of 0 is 0
                if (n == 1) return 1; // Fibonacci of 1 is 1

                // Variables to store the previous two Fibonacci numbers
                int a = 0; // F(0)
                int b = 1; // F(1)

                // Iteratively calculate Fibonacci numbers up to n
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b; // Calculate the next Fibonacci number
                    a = b; // Update a to the previous Fibonacci number
                    b = temp; // Update b to the current Fibonacci number
                }

                return b; // Return the nth Fibonacci number
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
