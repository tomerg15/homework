using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp88
{
    class LinkedList<Node> : IEnumerable<int>
    {
        private Node<int> head;
        private Node<int> end;
        private Node<int> max;
        private Node<int> min;
        private bool flag_first_node = true;

        public LinkedList(Node<int> head)
        {
            this.head = head;
            max = head;
            min = head;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return GetEnumerator(); 
        }

        public void Append(int value) //O(1)
        {
            Node<int> temp = new Node<int>(value);
            if (flag_first_node == true)
            {
                head.SetNext(temp);
                end = head.GetNext();
                flag_first_node = false;
            }
            else
            {
                end.SetNext(temp);
                end = end.GetNext();
            }
            if (temp.GetValue() > max.GetValue())
            {
                max = temp;
            }
            if (temp.GetValue() < min.GetValue())
            {
                min = temp;
            }
        }

        public void Prepend(int value)
        {
            Node<int> newhead = new Node<int>(value, head);
            head = newhead;
            if (newhead.GetValue() > max.GetValue())
            {
                max = newhead;
            }
            if (newhead.GetValue() < min.GetValue())
            {
                min = newhead;
            }
        }

        public int Pop()
        {
            Node<int> lst = head;
            while (lst.GetNext().GetNext() != null)
            {
                lst = lst.GetNext();
            }
            int value_of_last = lst.GetNext().GetValue();
            lst.SetNext(null);
            return value_of_last;
        }

        public int Unqueue()
        {
            int value_of_first = head.GetValue();
            head = head.GetNext();
            return value_of_first;
        }

        public IEnumerable<int> ToList()
        {
            IEnumerable<int> Enumlist = head as IEnumerable<int>;
            return Enumlist;
        }

        public bool IsCircular()
        {
            Node<int> slow = head, fast = head;
            while (slow != null && fast != null && fast.GetNext() != null)
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            int num;
            int temp;
            Node<int> pos;
            Node<int> lst = head;
            while (lst.HasNext())
            {
                num = lst.GetValue();
                pos = lst.GetNext();
                while (pos != null)
                {
                    if (num > pos.GetValue())
                    {
                        temp = num;
                        num = pos.GetValue();
                        pos.SetValue(temp);
                    }
                    pos = pos.GetNext();
                }
                lst.SetValue(num);
                lst = lst.GetNext();
            }
        }

        public Node<int> GetMaxNode()
        {
            return max;
        }

        public Node<int> GetMinNode()
        {
            return min;
        }
        public override string ToString()
        {
            return head.GetValue() + " -->" + head.GetNext();
        }
    }
}
