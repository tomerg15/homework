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
        private bool flag_first_node = true;

        public LinkedList(Node<int> head)
        {
            this.head = head;
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
            if (flag_first_node == true)
            {
                head.SetNext(new Node<int>(value));
                end = head.GetNext();
                flag_first_node = false;
            }
            else
            {
                end.SetNext(new Node<int>(value));
                end = end.GetNext();
            }
        }

        public void Prepend(int value)
        {
            Node<int> newhead = new Node<int>(value, head);
            head = newhead;
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
            Node<int> lst = head;
            Node<int> max = new Node<int>(lst.GetValue(),null);
            while (lst != null)
            {
                if (lst.GetValue() > max.GetValue())
                {
                    max = lst;
                }
                lst = lst.GetNext();
            }
            return max;
        }

        public Node<int> GetMinNode()
        {
            Node<int> lst = head;
            Node<int> min = new Node<int>(lst.GetValue(), null);
            while (lst != null)
            {
                if (lst.GetValue() < min.GetValue())
                {
                    min = lst;
                }
                lst = lst.GetNext();
            }
            return min;
        }
        public override string ToString()
        {
            return head.GetValue() + " -->" + head.GetNext();
        }
    }
}
