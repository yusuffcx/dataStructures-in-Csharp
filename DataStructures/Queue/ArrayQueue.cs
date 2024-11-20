namespace DataStructures.Queue
{
    internal class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> list = new List<T>();
        public int Count { get; private set; }


        public T DeQueue()
        {
            if(list.Count == 0) { throw new InvalidOperationException(); }
            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void EnQueue(T item)
        {
            if(item == null) { throw new ArgumentNullException("item"); }
            list.Add(item);
            Count++;
        }

        public T Peek()
        {
            if(list.Count == 0) { throw new Exception(); }
            return list[0];
        }
    }
}