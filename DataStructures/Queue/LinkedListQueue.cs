using DataStructures.LinkedList.DoublyLinkedList;

namespace DataStructures.Queue
{
    internal class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();

        public int Count { get; private set; }

        public T DeQueue()
        {
            if (Count == 0) { throw new Exception(); }
            var t = list.RemoveFirst();
            Count--;
            return t;
        }

        public void EnQueue(T item)
        {
            list.AddLast(item);
            Count++;
        }

        public T Peek()
        {
            if(Count == 0) { throw new Exception(); }  
            var t = list.Head.Value;
            return t;
        }
    }
}