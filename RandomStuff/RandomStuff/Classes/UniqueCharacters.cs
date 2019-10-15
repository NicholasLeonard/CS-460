using System;
using System.Collections.Generic;
using System.Text;
using RandomStuff.Interfaces;

namespace RandomStuff.Classes
{
    class UniqueCharacters:StringAlgorithms, IUniqueCharacters
    {
        private bool[] characters = new bool[128];
        private String inputString;

        public UniqueCharacters()
        {
            inputString = "Default";
        }

        //not currently used in this code implementation, but here if necessary
        public UniqueCharacters(String input)
        {
            inputString = input;
        }

        //checks to see if all of the characters of a string are unique
        public bool IsUnique()
        {
            //If the string length is greater than 128, then it is not unique because of the limitations of ascii representation
            if(inputString.Length > 128)
            {
                return false;
            }

            //checks to see if the input string contains all unique characters
            for(int i = 0; i < inputString.Length; i++)
            {//gets char value at index
                int val = inputString[i];

                //checks to see if that value has already been discovered in the string
                if(characters[val] == true)
                {
                    return false;
                }

                //sets the index of that value to true
                characters[val] = true;
            }

            return true;
        }

        //gets the input from the user and executes the IsUnique algorithim on the input
        public override void Input()
        {
            Console.WriteLine("\nPlease enter a string to check for unique characters.");

            inputString = Console.ReadLine();

            Console.WriteLine(this.IsUnique());
        }
    }
}
