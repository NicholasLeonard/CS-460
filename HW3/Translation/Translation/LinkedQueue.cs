using System;

namespace Translation
{/// <summary>
/// FIFO Queue that implements IQueueInterface.
/// </summary>
/// <typeparam name="T"></typeparam>
    public class LinkedQueue<T>:IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

       public LinkedQueue()
        {
            front = null;
            rear = null;
        }
        /// <summary>
        /// Used to push new elements into the queue.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Push(T element)
        {
            if( element == null )
            {
                throw new NullReferenceException();
            }

            if ( IsEmpty() )
            {//creates first node in queue
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;
            }
            else
            {
                //General case
                Node<T> tmp = new Node<T>(element, null);
                rear.Next = tmp;
                rear = tmp;
            }
            return element;
        }

        /// <summary>
        /// Used to remove elements from the queue.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {//C# quirk, Genenric types cannot equal null. Use default to set null values for all types.
            T tmp = default(T);
            if(IsEmpty())
            {
                throw new QueueUnderFlowException("The queue was empty when pop was invoked.");
            }
            else if( front == rear)
            {// one item in queue
                tmp = front.Data;
                front = null;
                rear = null;
            }
            else
            {// General case
                tmp = front.Data;
                front = front.Next;
            }

            return tmp;
        }

        /// <summary>
        /// Tests if the queue is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if( front == null && rear == null)
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