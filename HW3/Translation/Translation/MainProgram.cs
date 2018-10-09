using System;
using System.Collections.Generic;
using System.Text;

namespace Translation
{
    public class MainProgram
    {
        /**
     * Print the binary representation of all numbers from 1 up to n.
     * This is accomplished by using a FIFO queue to perform a level 
     * order (i.e. BFS) traversal of a virtual binary tree that 
     * looks like this:
     *                 1
     *             /       \
     *            10       11
     *           /  \     /  \
     *         100  101  110  111
     *          etc.
     * and then storing each "value" in a list as it is "visited".
     */
     static LinkedList<string> GenerateBinaryRepresentationList(int n)
        {
            //Create an empty queue of strings with which to perform the traversal.
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            //A list for returning the binary values
            LinkedList<string> output = new LinkedList<string>();

            if(n < 1)
            {
                //binary representation of negative values is not suppported return an empty list
                return output;
            }

            //Enqueue the first binary number. Use a dynamic string to avoid string concat
            q.Push(new StringBuilder("1"));

            //BFS
            while(n-- > 0)
            {
                //print the font of queue. possibly put try catch here.
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                //make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());

                //Left child
                sb.Append("0");
                q.Push(sb);
                //Right child
                sbc.Append("1");
                q.Push(sbc);
            }
            return output;
        }

        //Driver program to test above function
        static void Main(string[] args)
        {

        }
    }

}
