using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class Queue<T>
    {
        private readonly IQueue<T> queue;
        public int Count => queue.Count;

        public Queue( QueueType t = QueueType.Array)
        {
            if(t == QueueType.LinkedList)
            {
                queue = new LinkedListQueue<T>();
            }
            else
            {
                queue = new ArrayQueue<T>();
            }
        } 
        public void EnQueue(T item)
        {
            queue.EnQueue(item);
        }

        public T DeQueue()
        {
            return queue.DeQueue();
        }

        public T Peek()
        {
            return queue.Peek();
        }

    }

    public interface IQueue<T>
    {
        int Count { get; }
        void EnQueue(T item);
        T DeQueue();
        T Peek();
    }

    public enum QueueType
    {
        Array = 0,
        LinkedList = 1,
    }
}
