using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
Дано бинарное дерево, состоящее из N уровней. В каждом узле два потомка: А со значением 1 и В со значением -1.
Вывести в файл все возможные варианты путей, при которых сумма значений 0. У вершины С занчение 0.
 */
namespace recur27
{
    class Program
    {
        static void Main(string[] args)
        {
            //очищение файла
            FileStream file = new FileStream("C:\\Users\\SunRay\\Documents\\summer-practice-2019\\recur27\\file.txt", FileMode.Create);
            file.Close();
            //ввод N и высчитывание количества элементов в дереве
            Console.Write("N: ");
            int N = Convert.ToInt16(Console.ReadLine());
            int num = 0;
            for (int i = 0; i <= N; i++)
            {
                num += (int)Math.Pow(2, i);
            }
            alg("C", num, 0, 0);
        }
        //В результате выполнения метода alg формируется строка str, в которой содержится удовлетворяющий условиям путь.
        //результат работы программы находится в файле file.txt, располагающемся в папке с решением
        static void alg(string str, int num, int value, int i)
        {
            //ЕСЛИ нет детей И суммарный вес равен 9
            if (!isLeftChild(num, i) && value == 0)
            {
                //запись в файл строки str
                FileStream file = new FileStream("C:\\Users\\SunRay\\Documents\\summer-practice-2019\\recur27\\file.txt", FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine(str);
                writer.Close();
                file.Close();
            }
            else
            {
                //рекурсивные вызовы при наличии детей
                if (isLeftChild(num, i))
                {
                    alg(str + 'A', num, value+1, leftChild(i));
                    alg(str + 'B', num, value-1, rightChild(i));
                }
            }
        }
        //проверка сществования левого ребенка
        static bool isLeftChild(int num, int i)
        {
            if (i * 2 + 1 <= num)
                return true;
            else return false;
        }
        //получение левого ребенка
        static int leftChild(int i)
        {
            return i * 2 + 1;
        }
        //получение правого ребенка
        static int rightChild(int i)
        {
            return i * 2 + 2;
        }
    }
}
