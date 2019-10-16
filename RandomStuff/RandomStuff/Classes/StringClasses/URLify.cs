using System;
using System.Collections.Generic;
using System.Text;
using RandomStuff.Interfaces;

namespace RandomStuff.Classes.StringClasses
{
    class URLify : StringAlgorithms, IURLify
    {
        private string url;

        public URLify()
        {
            url = "Default";
        }

        public URLify(string url)
        {
            this.url = url;
        }

        // sanatizes the string by removing spaces
        public string MakeURLSafe()
        {// replaces the spaces in the string with %20 to make it safe for a url
           url = url.Replace(" ", "%20");

            return url;
        }

        public override void Input()
        {
            Console.WriteLine("Please enter the string to URLify!");
            url = Console.ReadLine();

            Console.WriteLine(MakeURLSafe());
        }
    }
}
