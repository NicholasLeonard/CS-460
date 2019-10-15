using System;
using System.Collections.Generic;
using System.Text;
using RandomStuff.Interfaces;

namespace RandomStuff.Classes
{
    class UniqueCharacters:IUniqueCharacters
    {
        private bool[] characters = new bool[128];
        private String inputString;

        public UniqueCharacters()
        {
            inputString = "Default";
        }

        public UniqueCharacters(String input)
        {
            inputString = input;
        }

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
    }
}
