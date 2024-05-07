using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp88
{
    class Node<T>
    {
        private int value;
        private Node<T> next;
        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }
        public Node(int value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        public int GetValue()
        {
            return this.value;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        public bool HasNext()
        {
            return (this.next != null);
        }
        public void SetValue(int value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public override string ToString()
        {
            return value + " -->" + next;
        }
    }
}
