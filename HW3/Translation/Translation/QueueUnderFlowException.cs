using System;

namespace Translation
{    /// <summary>
    /// A custom exception to represent situations where an illegal operation was performed on an empty queue.
    /// </summary>
    public class QueueUnderFlowException : Exception
    {//user made exception with no message.
        public QueueUnderFlowException() : base()
        {
        }

        //user made exception that displays a message.
        public QueueUnderFlowException(string message) : base(message)
        {
        }
    }

}