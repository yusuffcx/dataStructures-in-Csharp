using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    internal class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail  { get; set; }


        public DoublyLinkedList(IEnumerable<T>collection)
        {
            foreach(var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if(Head != null)
            {
                newNode.Next = Head;
                Head = newNode;
                newNode.Prev = null;
            }

            if(Tail == null)
            {
                Tail = Head;
            }

        }

        public void AddLast(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if(Tail == null)
            {
                AddFirst(value);
                return;
            }

            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            return;
        }

        public void AddAfter(DoublyLinkedListNode<T>refNode,T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (refNode == null)
            {
                throw new Exception();
            }
            if (Head == refNode && Tail == refNode)
            {
                refNode.Next = newNode;
                newNode.Prev = refNode;
                refNode.Prev = null;
                newNode.Next = null;
                Head = refNode;
                Tail = newNode;
                return;
            }
                    newNode.Next = refNode.Next;
                    newNode.Prev = refNode;
                    refNode.Next.Prev = newNode;
                    refNode.Next = newNode;
                    if(Tail == refNode)
                    {
                        Tail = newNode;
                    }
                    return;
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode, T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (refNode == null)
            {
                throw new Exception();
            }
            if (Head == refNode && Tail == refNode)
            {
                refNode.Next = newNode;
                newNode.Prev = refNode;
                refNode.Prev = null;
                newNode.Next = null;
                Head = newNode;
                Tail = refNode;
                return;
            }
            newNode.Next = refNode;
            newNode.Prev = refNode.Prev;
            refNode.Prev.Next = newNode;
            refNode.Prev = newNode;
            return;
        }

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var cur = Head;
            while(cur!= null)
            {
                list.Add(cur);
                cur = cur.Next;
            }
            return list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }

        public T RemoveFirst()
        {
            if(Head == null)
            {
                throw new Exception("there is no element to remove");
            }
            var temp = Head.Value;

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                return temp;
            }

            Head = Head.Next;
            Head.Prev = null;
            return temp;
        }

        public T RemoveLast()
        {
            if(Tail == null)
            {
                throw new Exception("there is no element to remove");
            }
            var temp = Tail.Value;

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                return temp;
            }

            Tail = Tail.Prev;
            Tail.Next = null;
            return temp;
        }

        public T Remove(T item)
        {
            if(Tail == null || Head == null)
            {
                throw new ArgumentException();
            }
            var cur = Head;
            while(cur != null)
            {
                if(cur.Value.Equals(item))
                {
                    cur.Prev.Next = cur.Next;
                    cur.Next.Prev = cur.Prev;
                    cur = null;
                    return item;
                }
            }
            throw new NotImplementedException(); 
        }

    }
}
