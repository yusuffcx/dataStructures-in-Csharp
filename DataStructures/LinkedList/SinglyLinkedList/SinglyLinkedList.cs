using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedList(IEnumerable<T>collection) 
        {
            foreach (var item in collection)
            {
                this.AddFirst(item);
            }
        }
        public SinglyLinkedList()
        {
            
        }

        public SinglyLinkedListNode<T> Head { get; set; }

        public void AddFirst(T item)
        {
            var newNode = new SinglyLinkedListNode<T>(item);
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T item)
        {
            var newNode = new SinglyLinkedListNode<T>(item);
            if(Head == null)
            {
                this.AddFirst(item);
                return;
            }
            var curNode = Head;
            while(curNode.Next != null)
            {
                curNode = curNode.Next;
            }
            curNode.Next = newNode; 
        }

        public void AddAfter(SinglyLinkedListNode<T>node,T item)
        {
            var curNode = Head;
            if(node == null)
            {
                throw new ArgumentNullException();
            }

            if (Head == null)
            {
                AddFirst(item);
                return;
            }

            while (curNode.Next!= null)
            {
                if (curNode.Next == node)
                {
                    var newNode = new SinglyLinkedListNode<T>(item);
                    newNode.Next = curNode.Next;
                    curNode.Next = newNode;
                    return;
                } 
                curNode = curNode.Next;
            }
            throw new ArgumentException();
        }

        public void AddBefore(SinglyLinkedListNode<T>node,T item)
        {
            var curNode = Head;

            if (Head == null)
            {
                AddFirst(item);
                return;
            }

            while(curNode != null)
            {
                if(curNode.Next == node)
                {
                    var newNode = new SinglyLinkedListNode<T>(item);
                    newNode.Next = curNode.Next;
                    curNode.Next = newNode;
                    return;
                }
                curNode = curNode.Next;  
            }
            throw new ArgumentException();
        }

        public void AddAfter(SinglyLinkedListNode<T>refNode ,SinglyLinkedListNode<T>node )
        {
            var curNode = Head;
            if (Head == null)
            {
                return;
            }
            if (refNode == null || node == null)
            {
                throw new ArgumentNullException();
            }


            while (curNode != null)
            {
                if(curNode == refNode)
                {
                    node.Next =  refNode.Next;
                    refNode.Next = node;
                    return;
                }
                curNode = curNode.Next;
            }
            throw new ArgumentException();
        }

        public void AddBefore(SinglyLinkedListNode<T>refNode,SinglyLinkedListNode<T>node)
        {
            var curNode = Head; 
            if (Head == null || refNode == null || node == null)
            {
                throw new ArgumentNullException();
            }

            if(Head == refNode)
            {
                node.Next = refNode;
                Head = node;

            }

            while(curNode != null)
            {
                if(curNode.Next == refNode)
                {
                    node.Next = curNode.Next;
                    curNode.Next = node;
                    return;
                }
                curNode = curNode.Next;
            }
            throw new ArgumentException();
        }
        public T FirstRemove()
        {
            if(Head != null) 
            {
                var firstValue = Head.Value;
                Head = Head.Next;
                return firstValue;
            }
            throw new  ArgumentException("Silinecek eleman yok!");
        }

        public T LastRemove()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while(current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = current.Value;
            prev.Next = null;
            return lastValue;
        }

        public void Remove(T value)
        {

            if(Head == null)
            {
                throw new Exception("'Listte eleman yok.'");
            }
            if(value == null)
            {
                throw new ArgumentNullException();
            }
            SinglyLinkedListNode<T> prev = null;
            var cur = Head;

            do
            {
                if (cur.Value.Equals(value)) // eşit mi
                {
                    if(cur == Head) 
                    {
                        Head = Head.Next;
                        return;
                    }
                    if(cur.Next == null)
                    {
                        if(prev == null)
                        {
                            Head = null;
                            return;
                        }
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        prev.Next = cur.Next;
                        return;
                    }
                }
                else
                {
                    prev = cur;
                    cur = cur.Next;
                }

            } while (cur != null);

        }



        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


