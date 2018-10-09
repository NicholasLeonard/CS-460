
namespace Translation
{
    public interface IQueueInterface<T>
    {
        /*Add an element to the rear of the queue and return the element that was enqueued*/
        T Push(T element);

        /*Remove and return the front element
         throws QueueUnderFlowException if queue is empty*/
           /// <summary>
           /// 
           /// </summary>
           /// <returns></returns>
           
        T Pop();

        /*Test if the queue is empty. Return true if empty.*/

        bool IsEmpty();
    }
}