using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStuff.Classes.StringClasses
{
    //Base class for all of the string based algorithims
    abstract class StringAlgorithms
    {
        //handles getting the input string from the user
        public abstract void Input();
        
        public void Initiate()
        {
            this.Input();
        }
    }
}
