using System;
using System.Collections.Generic;
using System.Text;
using RandomStuff.Interfaces;

namespace RandomStuff.Classes.StringClasses
{
    class OneAway : StringAlgorithms, IOneAway
    {
        private string a;
        private string b;

        public OneAway()
        {
            a = "Default";
            b = "Default";
        }

        public OneAway(string a)
        {
            this.a = a;
            b = "Default";
        }

        public OneAway(string a, string b)
        {
            this.a = a;
            this.b = b;
        }

        // Checks to see if the two strings are one edit away from eachother.
        public bool IsOneAway()
        {
            // Used to keep track of the total number of different letters between the two strings.
            int numOfDifferentLetters = 0;

            // Initializes two Dictionaries to contain the letters and letter counts for each string to compare against each other for number of differences.
            Dictionary<int, int> aStringDictionary = new Dictionary<int, int>(128);
            Dictionary<int, int> bStringDictionary = new Dictionary<int, int>(128);

            // Sanatizes the strings to remove any spaces or capitalized letters and converts them to char arrays to be sorted alphabetically for letter comparison.
            a = a.Replace(" ", "").ToLower();
            b = b.Replace(" ", "").ToLower();

            // Populates the astring Dictionary with its corresponding letters and letter counts.
            aStringDictionary = PopulateLetterDictionary(a, aStringDictionary);

            // Populates the bstring Dictionary with its corresponding letters and letter counts.
            bStringDictionary = PopulateLetterDictionary(b, bStringDictionary);

            // If there are more than 2 letters different, then there is no point in going further.
            if(aStringDictionary.Keys.Count > bStringDictionary.Keys.Count + 1 || bStringDictionary.Keys.Count > aStringDictionary.Keys.Count + 1)
            {
                return false;
            }

            var aStringKeys = aStringDictionary.Keys;
            var bStringKeys = bStringDictionary.Keys;

            // We want to use the shorter of the two so there is no bounds problems.
            if(aStringKeys.Count <= bStringKeys.Count)
            {
                // Determines if the letter from aString is in bString. If it is not, it adds 1 to the current different letters total.
                // If it is, it makes sure that the total number of those letters in each string matches. If not, then it adds one to the total different letters total.
                foreach(var letter in aStringKeys)
                {
                    if (!bStringDictionary.ContainsKey(letter))
                    {
                        numOfDifferentLetters++;
                    }
                    else if(bStringDictionary[letter] != aStringDictionary[letter])
                    {
                        numOfDifferentLetters++;
                    }
                }
            }
            else
            {
                foreach(var letter in bStringKeys)
                {
                    if (!aStringDictionary.ContainsKey(letter))
                    {
                        numOfDifferentLetters++;
                    }
                    else if(aStringDictionary[letter] != bStringDictionary[letter])
                    {
                        numOfDifferentLetters++;
                    }
                }
            }

            // If there is more than one difference between the two strings, it returns false.
            if(numOfDifferentLetters > 1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Used to populate a dictionary with letters and their corresponding counts in a string.
        /// </summary>
        /// <param name="dictionaryString"></param>
        /// <param name="letterDictionary"></param>
        /// <returns></returns>
        private Dictionary<int, int> PopulateLetterDictionary(string dictionaryString, Dictionary<int, int> letterDictionary)
        {
            // Populates the Dictionary with its corresponding letters and letter counts.
            for(int i = 0; i < dictionaryString.Length; i++)
            {
                int letterKey = dictionaryString[i];

                // If the letter is not already recorded in the dictionary, it adds it. Otherwise, it adds 1 to the current number of recorded letters.
                if (!letterDictionary.ContainsKey(letterKey))
                {
                    letterDictionary.Add(letterKey, 1);
                }
                else
                {
                    letterDictionary[letterKey] = letterDictionary[letterKey] + 1;
                }
            }

            // Returns the newly populated letter Dictionary.
            return letterDictionary;
        }

        public override void Input()
        {
            Console.WriteLine("\nPlease enter the first string.");
            a = Console.ReadLine();

            Console.WriteLine("\nPlease enter the second string.");
            b = Console.ReadLine();

            if(a.Length == 0 || b.Length == 0)
            {
                Console.WriteLine("I'm sorry. A string cannot be null.");
                Input();
            }

            int differenceInLength = a.Length - b.Length;

            switch (differenceInLength)
            {
                case 1:
                case -1:
                case 0:
                    Console.WriteLine(IsOneAway());
                    break;
                default:
                    Console.WriteLine("I'm sorry. Both strings must have a difference in length of no more than one.");
                    Input();
                    break;
            }
        }
    }
}
