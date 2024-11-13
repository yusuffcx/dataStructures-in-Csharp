namespace DataStructures.Stack
{
    internal class ArrayStack<T> : IStack<T>
    {
        public int Count {  get; private set; }
        private readonly List<T> list = new List<T>();

        public T Peek()
        {
            if(Count == 0)
            {
                throw new Exception();
            }

            return list[list.Count - 1];
        }

        public T Pop()
        {
            var deletedValue = list[list.Count-1];
            if (Count == 0)
            {
                throw new Exception();
            }
            list.RemoveAt(list.Count - 1);
            Count--;
            return deletedValue;
        }

        public void Push(T value)
        {
            list.Add(value);
            Count++;
        }
    }
}