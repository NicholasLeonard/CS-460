
namespace Translation
{/// <summary>
/// Interface for different queue types.
/// </summary>
/// <typeparam name="T"></typeparam>
    public interface IQueueInterface<T>
    {
        /// <summary>
        /// Add an element to the rear of the queue and return the element that was enqueued.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        T Push(T element);

           /// <summary>
           /// Remove and return the front element and throws a QueueUnderFlowException if the queue is empty.
           /// </summary>
           /// <returns></returns>
           
        T Pop();

        /*Test if the queue is empty. Return true if empty.*/
        /// <summary>
        /// Test if the queue is empty. Return true if the queue is empty; false otherwise.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
    }
}