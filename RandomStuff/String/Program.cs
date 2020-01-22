using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "Hello World!";
            string B = "!dlroW olleH";

            Console.WriteLine(StringRotation.IsRotation(A, B));
        }
    }
}
