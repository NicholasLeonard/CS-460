using System;
using System.Collections.Generic;
using System.Text;
using RandomStuff.Interfaces;

namespace RandomStuff.Classes.StringClasses
{
    class StringCompression : StringAlgorithms, IStringCompression
    {
        private string inputString;

        public StringCompression()
        {
            inputString = "hello";
        }

        public StringCompression(string inputString)
        {
            this.inputString = inputString;
        }

        public string Compress()
        {
            // Creates a StringBuilder class to make string concatenation more efficient.
            StringBuilder compressedString = new StringBuilder();
            int letterTally = 1;

            for(int i = 0; i < inputString.Length; i++)
            {
                char currentLetter = inputString[i];

                try
                {
                    if (currentLetter == inputString[i + 1])
                    {
                        letterTally++;
                    }
                    else
                    {
                        compressedString.Append(currentLetter.ToString() + letterTally.ToString());
                        letterTally = 1;
                    }
                }
                catch(IndexOutOfRangeException e)
                {
                    compressedString.Append(currentLetter.ToString() + letterTally.ToString());
                }
            }
            
            if(inputString.Length <= compressedString.Length)
            {
                return inputString;
            }
            else
            {
                return compressedString.ToString();
            }
        }

        public override void Input()
        {
            Console.WriteLine("Please enter a string to be compressed.");
            inputString = Console.ReadLine();

            if (inputString.Contains(@"^[a-zA-Z]"))
            {
                Console.WriteLine("\nI'm sorry. This algorithm only accepts characters a-z and A-Z. Please try again.");
                Input();
            }
            else
            {
                Console.WriteLine(Compress());
            }
        }
    }
}
