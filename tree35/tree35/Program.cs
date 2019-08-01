using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Удвоение значений всех вершин

namespace tree35
{
    class Program
    {
        static int k = 1;
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
            double_nodes_value(root);
            root.treeOut(Console.WindowWidth / 2, 12, 0);
            Console.Read();
        }
        static void double_nodes_value(Node node)
        {
            node.value = node.value * 2;
            if (node.leftChild != null)
                double_nodes_value(node.leftChild);
            if (node.rightChild != null)
                double_nodes_value(node.rightChild);
        }
        static void formin_tree(int nodes_amount, int tree_level, double max, int tmp_lvl_1, Node node, int[] value_mas)
        {
            if (tmp_lvl_1 < tree_level && k < nodes_amount && k <= max)
            {
                if (node.leftChild == null)
                {
                    tmp_lvl_1++;
                    node.leftChild = new Node(value_mas[k]);
                    k++;
                    formin_tree(nodes_amount, tree_level, max, tmp_lvl_1, node.leftChild, value_mas);
                    tmp_lvl_1--;
                }
                if (node.rightChild == null)
                {
                    tmp_lvl_1++;
                    node.rightChild = new Node(value_mas[k]);
                    k++;
                    formin_tree(nodes_amount, tree_level, max, tmp_lvl_1, node.rightChild, value_mas);
                    tmp_lvl_1--;
                }
            }
        }
    }
}
