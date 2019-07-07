using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Даны числа D1, D2 и указатель P0 на один из элементов двусвязного списка.
//Добавить D1 и D2 в начало и в конец списка соответственно. Вывести их адреса

namespace dynamic32
{
    class Program
    {
        static void Main(string[] args)
        {
            //создание списка и его заполнение
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            //ввод значений D1, D2, и указателя P0
            Console.Write("D1: ");
            int D1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("D2: ");
            int D2 = Convert.ToInt16(Console.ReadLine());
            LinkedListNode<int> P0 = list.First.Next.Next;
            //добавление D1 в начало списка
            while (P0.Previous != null)
                P0 = P0.Previous;
            list.AddBefore(P0, D1);
            //C# не позволяет работать с адресами в связных списках, но если бы это было возможно,
            //то строка ниже позволила бы нам получить адрес для D1
            //Console.WriteLine("Адрес D1: " + &P0.Previous);
            //добавление D2 в конец списка
            while (P0.Next != null)
                P0 = P0.Next;
            list.AddAfter(P0, D2);
            //вывод элементов списка
            while (list.Count != 0)
            {
                Console.WriteLine(list.First.Value);
                list.RemoveFirst();
            }
            Console.Read();
        }
    }
}
