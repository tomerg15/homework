using System;

namespace ConsoleApp88
{
    class Program
    {
        static void Main()
        {
            //checking functions: all works fine! :D
            Node<int> node1 = new Node<int>(2);
            LinkedList<Node<int>> head = new LinkedList<Node<int>>(node1);
            Console.WriteLine(head);
            head.Append(3);
            head.Append(4);
            head.Prepend(1);
            head.Sort();
            head.Unqueue();
            head.Pop();
            Console.WriteLine(head);
            NumericalExpression<long> number = new NumericalExpression<long>(42548);
            Console.WriteLine(number);
            Console.ReadLine();

        }
    }
}
