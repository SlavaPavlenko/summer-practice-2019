using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic32
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            Console.Write("D1: ");
            int D1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("D2: ");
            int D2 = Convert.ToInt16(Console.ReadLine());
            LinkedListNode<int> node = list.First.Next.Next;
            while (node.Previous != null)
                node = node.Previous;
            list.AddBefore(node, D1);
            while (node.Next != null)
                node = node.Next;
            list.AddAfter(node, D2);
            /*
            list.AddFirst(D1);
            list.AddLast(D2);
            */
            while (list.Count != 0)
            {
                Console.WriteLine(list.First.Value);
                list.RemoveFirst();
            }
            Console.Read();
        }
    }
}
