using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;
using System;

namespace DataStructures // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var arr = new DataStructures.Array.Array<int>();
            Console.WriteLine($"{arr.Count} / {arr.Capacity}");


            foreach( var item in arr )
            {
                Console.WriteLine( item );
            }*/

            //arr.Where(x => x%2 == 0).ToList().ForEach(x => Console.WriteLine( x ));
            /*
            var linkedList = new SinglyLinkedList<int>();

            linkedList.AddLast(4);
            foreach (int i in linkedList)
            {
                Console.WriteLine(i);
            }

            var rnd = new Random();
            var initial = Enumerable.Range(3,12).OrderBy(i => rnd.Next()).ToList();
            var linked = new SinglyLinkedList<int>(initial);
            var q = from item in linkedList where item%2 == 1 select item;

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }*/
           /* var list = new SinglyLinkedList<int>(new int[] {23,44,32,55});
            list.Remove(32);
            list.Remove(55);
            list.Remove(23);
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }*/

            var list = new DoublyLinkedList<int>();
            //list.AddFirst(12);
            //list.AddFirst(23);
            list.AddLast(45);

            foreach(var i in list)
            {
                Console.WriteLine(i);
            }

        }
    }
}


