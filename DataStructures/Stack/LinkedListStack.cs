using DataStructures.LinkedList.SinglyLinkedList;

namespace DataStructures.Stack
{
    internal class LinkedListStack<T> : IStack<T>
    {

        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count { get; private set; }

        public T Peek()
        {
            if(Count == 0) { throw new InvalidOperationException(); }
            return list.Head.Value;
        }

        public T Pop()
        {
            var deletedValue = list.Head.Value;
            list.FirstRemove();
            Count--;
            return deletedValue;
        }

        public void Push(T value)
        {
            list.AddFirst(value);
            Count++;
        }
    }
}
