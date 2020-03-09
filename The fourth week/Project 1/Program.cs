using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication
{

    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }
        public Node<T> Tail
        {
            get => tail;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            if (tail == null)
            {
                Console.WriteLine("链表为空，操作无效");
                return;
            }
            Node<T> p = head;
            while (p != null)
            {
                action(p.Data);
                p = p.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }//把0,1,2，……，9都加入链表中

            int max = -2147483648;
            int min = 2147483647;
            int sum = 0;
            intlist.ForEach(x => Console.WriteLine($"{x}"));
            intlist.ForEach(x => max = x > max ? x : max);
            intlist.ForEach(x => min = x < min ? x : min);
            intlist.ForEach(x => sum += x);
            Console.WriteLine($"最大值为{max},最小值为{min},和为{sum}");

            /*

            for (Node<int> node = intlist.Head; 
                  node != null; node = node.Next) {
              Console.WriteLine(node.Data);
            }

            // 字符串型List
            GenericList<string> strList = new GenericList<string>();
            for (int x = 0; x < 10; x++) {
              strList.Add("str"+x);
            }
            for (Node<string> node = strList.Head; 
                    node != null; node = node.Next) {
              Console.WriteLine(node.Data);
            }
            */

        }

    }
}