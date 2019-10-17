using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using RandomStuff.Interfaces;


namespace RandomStuff.Classes.StringClasses
{
    class PalindromePermutation : StringAlgorithms, IPalindromePermutation
    {
        private string inputString;

        public PalindromePermutation()
        {
            inputString = "Default";
        }

        public PalindromePermutation(string inputString)
        {
            this.inputString = inputString;
        }

        public bool IsPalindromePermutation()
        {// Initializes a hashtable with the capacity to store standared ASCII letters.
            Dictionary<int, int> hashtable = new Dictionary<int, int>(128);

            // Sanatizes the string to prepare for manipulation.
            inputString = inputString.ToLower().Replace(" ", "");

            // Iterates through the string recording the letters and the total counts of those letters in the string.
            for (int i = 0; i < inputString.Length; i++)
            {
                // Sets the key of the letter in the dictionary to the ASCII number of the current letter in the string.
                int letterKey = inputString[i];

                // If the table doesn't currently contain this entry, it adds it to the dictionary.
                if (!hashtable.ContainsKey(letterKey))
                {
                    hashtable.Add(letterKey, 1);
                }
                else
                {
                    hashtable[letterKey] = hashtable[letterKey] + 1;
                }
            }

            // Gets the total counts for each letter from the string to be checked for odd or evenness.
            ICollection letterCounts = hashtable.Values;
            int totalNumOfOddLetterCounts = 0;

            // Performs a check to see how many, if any, of the letter counts are odd. In order to be a permutation of a pallindrome, there can be no more than 1 letter that has an odd count.
            foreach (var count in letterCounts)
            {
                if ((int)count % 2 != 0)
                {
                    totalNumOfOddLetterCounts += 1;
                }
            }

            // If there is more than 1 letter that has an odd count, it returns false because it can't be a pallindrome.
            if(totalNumOfOddLetterCounts > 1)
            {
                return false;
            }

            return true;
        }
        
        public override void Input()
        {
            Console.WriteLine("Please enter a string to test if it is a permutation of a palindrome.");

            inputString = Console.ReadLine();

            Console.WriteLine(IsPalindromePermutation());
        }
    }
}
