using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    public static class StringRotation
    {
        /// <summary>
        /// Determines if string one is a rotation of string two. Returns false if either string is null. Is case and whitespace sensitive.
        /// </summary>
        /// <param name="str1">The possible rotated string.</param>
        /// <param name="str2">The string to compare too.</param>
        /// <returns></returns>
        public static bool IsRotation(string str1, string str2)
        {
            if(str1 == null || str2 == null)
            {
                return false;
            }

            char[] string1 = str1.ToCharArray();
            char[] string2 = str2.ToCharArray();
            Array.Sort(string1);
            Array.Sort(string2);

            if(string1.ToString() == string2.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
