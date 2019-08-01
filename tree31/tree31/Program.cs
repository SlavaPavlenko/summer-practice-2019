using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Формирование дерева из N вершин и L уровней в префиксном порядке
//Префиксный порядок - сначала действия происходят с вершиной, потом с ее левым и правым детьми

namespace tree31
{
    class Program
    {
        public static int k = 1;
        static void Main(string[] args)
        {
            Node root = null;
            try
            {
                Console.Write("N: ");
                int N = Convert.ToInt16(Console.ReadLine());
                Console.Write("L: ");
                int L = Convert.ToInt16(Console.ReadLine());
                if (N <= 0 || L <= 0 || N <= L)
                    throw new Exception();
                //заполнение массива значениями
                Random random = new Random();
                int[] mas = new int[N];
                for (int j = 0; j < N; j++)
                    mas[j] = random.Next(10);
                //максимальное кол-во вершин
                double max = 0;
                for (double j = 0; j < L; j++)
                    max += Math.Pow(2, j);
                //формирование дерева
                root = new Node(mas[0]);
                forming_tree(N, L, max, 1, root, mas);
            }
            catch (Exception)
            {
            }
            root.treeOut(Console.WindowWidth / 2, 3, 0);
            Console.Read();
        }
        static void forming_tree(int N, int L, double max, int lvl, Node node, int[] mas)
        {
            if (lvl < L && k < N && k <= max)
            {
                if (node.leftChild == null)
                {
                    lvl++;
                    node.leftChild = new Node(mas[k]);
                    k++;
                    forming_tree(N, L, max, lvl, node.leftChild, mas);
                    lvl--;
                }
                if (node.rightChild == null)
                {
                    lvl++;
                    node.rightChild = new Node(mas[k]);
                    k++;
                    forming_tree(N, L, max, lvl, node.rightChild, mas);
                    lvl--;
                }
            }
        }
    }
}
