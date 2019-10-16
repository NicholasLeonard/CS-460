using System;
using System.Collections.Generic;
using System.Text;
using RandomStuff.Interfaces;

namespace RandomStuff.Classes.StringClasses
{
    class CheckPermutation : StringAlgorithms, ICheckPermutation
    {
        private string a;
        private string b;

        public CheckPermutation()
        {
            a = "hello";
            b = "elloh";
        }

        public CheckPermutation(string a, string b)
        {
            this.a = a;
            this.b = b;
        }

        public CheckPermutation(string a)
        {
            this.a = a;
            b = "elloh";
        }

        // Checks if b string is a permutation of a string
        public bool IsPermutation()
        {// if the strings are not the same length they can't be permutations
            if(a.Length != b.Length)
            {
                return false;
            }
            
            // converts the strings into mutable char arrays
            char[] firststring = a.ToCharArray();
            char[] secondstring = b.ToCharArray();

            // sorts the strings into alphabetical order to make them identical
            Array.Sort(firststring);
            Array.Sort(secondstring);

            // checks each char to determine if the strings are identical
            for (int i = 0; i < firststring.Length; i++)
            {
               if(firststring[i] != secondstring[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override void Input()
        {
            Console.WriteLine("Please enter a string.");
            a = Console.ReadLine();

            Console.WriteLine("\nPlease enter the second string to be compared against the first for permutation.");
            b = Console.ReadLine();

            Console.WriteLine(IsPermutation());
        }
    }
}
