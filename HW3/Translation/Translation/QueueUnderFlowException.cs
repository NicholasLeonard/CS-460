using System;

namespace Translation
{/*A custom exception to represent situations where an illegal operation was performed on an empty queue.*/

    public class QueueUnderFlowException: Exception
    {
        public QueueUnderFlowException(string message) : base(message)
        {
        }
    }

}