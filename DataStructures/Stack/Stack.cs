﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    internal class Stack<T>
    {
        // StackType type = StackType.Array
        private readonly IStack<T> stack;
        public int Count => stack.Count;
        public Stack(StackType type = StackType.Array)
        {
            if (type == StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else
            {
                stack = new LinkedListStack<T>();
            }
        }
        public T Pop()
        {
            return stack.Pop();
        }
        public void Push(T value)
        {
           stack.Push(value);
        }

        public T Peek()
        {
            return stack.Peek();
        }



    }

    public interface IStack<T>
    {
        int Count { get; }
        void Push(T value);
        T Peek();
        T Pop();
    }

    public enum StackType
    {
        Array = 0,
        LinkedList = 1,
    }
}
