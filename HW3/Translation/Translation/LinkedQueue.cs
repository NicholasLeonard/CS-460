using System;

namespace Translation
{
    public class LinkedQueue<T>:IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

       public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        public T Push(T element)
        {
            if( element == null )
            {
                throw new NullReferenceException();
            }

            if ( IsEmpty() )
            {
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

        public T Pop()
        {
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