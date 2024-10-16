using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    internal class Array<T> : IEnumerable<T>
    {
        private T[] InnerList;
        public int Capacity => InnerList.Length;
        public int Count { get; private set; }

        public Array() 
        {
            InnerList = new T[2];
            Count = 0;
        }

        public Array(params T[] init)
        {
            InnerList = new T[init.Length];
        }

        public Array(IEnumerable<T> values)
        {
            InnerList = new T[values.ToArray().Length];
            Count = 0;
            foreach (var item in values)
            {
                Add(item);
            }

        }

        public void Add(T item)
        {
            if(Count == InnerList.Length)
            {
                DoubleArray();
            }
            InnerList[Count] = item;
            Count++; // eleman sayısı...
        }

        private T Remove()
        {
            if(Count == 0)
            {
                throw new Exception("Silinecek eleman yok.");
            }
            else if(InnerList.Length/4 == Count) 
            {
                HalfArray();
            }

            var temp = InnerList[Count-1];
            Count--;
            return temp;
        }

        private void HalfArray()
        {
            if(InnerList.Length > 2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, temp.Length);
                InnerList = temp;
            }

        }

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length * 2];
            System.Array.Copy(InnerList,temp, InnerList.Length);
            InnerList = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Select(item => item).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
