using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Удаление детей в префиксном порядке. Если вершина четная - удаляем правого, нечетная - левого

namespace tree43
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начальное дерево: ");
            //заполнение массива значениями
            Random random = new Random();
            int[] mas = new int[8];
            for (int i = 0; i < mas.Length; i++)
                mas[i] = random.Next(10);
            //максимальное кол-во вершин
            double max = 0;
            for (double j = 0; j < 3; j++)
                max += Math.Pow(2, j);
            //формирование дерева
            Node root = new Node(mas[0]);
            root.leftChild = new Node(mas[1]);
            root.rightChild = new Node(mas[2]);
            root.rightChild.rightChild = new Node(mas[3]);
            root.rightChild.leftChild = new Node(mas[4]);
            root.leftChild.leftChild = new Node(mas[5]);
            root.leftChild.leftChild.leftChild = new Node(mas[6]);
            root.leftChild.leftChild.rightChild = new Node(mas[7]);
            root.treeOut(Console.WindowWidth / 2, 2, 0);

            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Конечное дерево: ");
            alg(root);
            root.treeOut(Console.WindowWidth / 2, 12, 0);
            Console.Read();
        }
        static void alg(Node node)
        {
            if (node.leftChild != null && node.rightChild != null)
            {
                if (node.value % 2 == 1)
                {
                    node.leftChild = null;
                    GC.Collect();
                    alg(node.rightChild);
                }
                else
                {
                    node.rightChild = null;
                    GC.Collect();
                    alg(node.leftChild);
                }
            }
            else
            {
                if (node.leftChild != null)
                    alg(node.leftChild);
                if (node.rightChild != null)
                    alg(node.rightChild);
            }
        }
        /*
        static void freeMemory(Node node)
        {
            if (node.leftChild != null)
                freeMemory(node.leftChild);
            if (node.rightChild != null)
                freeMemory(node.rightChild);
            node.value = 0;
            node = null;
            GC.Collect();
        }
        */
    }
}
