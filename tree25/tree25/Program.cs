using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//создание N-уровневого дерева только из правых детей

namespace tree25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N: ");
            try
            {
                int N = Convert.ToInt16(Console.ReadLine());

                if (N > 0)
                {
                    int[] mas = new int[N];
                    Random random = new Random();
                    //заполнение массива значений для дерева
                    for (int i = 0; i < N; i++)
                        mas[i] = random.Next(10);
                    //заполнение дерева значениями из массива
                    Node root = new Node(mas[0]);
                    Node tmp = root;
                    for (int i = 1; i < N; i++)
                    {
                        tmp.addRight(mas[i]);
                        tmp = tmp.rightChild;
                    }
                    //вывод дерева
                    Console.SetCursorPosition(40, 2);
                    root.treeOut(Console.WindowWidth / 2, 2, 0);
                }
                else Console.WriteLine("Некорректное значение N");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }

        class Node
        {
            public int value { get; set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }
            public Node(int value)
            {
                this.value = value;
            }
            public void addLeft(int value)
            {
                this.leftChild = new Node(value);
            }
            public void addRight(int value)
            {
                this.rightChild = new Node(value);
            }
            public void treeOut(int offset, int level, int deep)
            {
                Console.SetCursorPosition(offset, level);
                Console.Write(this.value);
                if (leftChild != null)
                {
                    int curPos = offset - 2;
                    int childPos = -1;
                    childPos = (int)(curPos - Console.WindowWidth / Math.Pow(2, deep + 2));
                    switch (deep)
                    {
                        case 0:
                            childPos += 8;
                            break;
                        case 1:
                            childPos += 6;
                            break;
                        case 2:
                            childPos += 2;
                            break;
                        case 3:
                            childPos += 1;
                            break;
                    }
                    if (childPos >= 0)
                    {
                        Console.SetCursorPosition(childPos, level + 1);
                        Console.Write("/");
                        while (curPos > childPos)
                        {
                            Console.SetCursorPosition(curPos, level);
                            Console.Write("_");
                            curPos--;
                        }
                        this.leftChild.treeOut(childPos - 1, level + 2, deep + 1);
                    }
                }
                if (rightChild != null)
                {
                    int curPos = offset + 2;
                    int childPos = -1;
                    childPos = (int)(curPos + Console.WindowWidth / Math.Pow(2, deep + 2));
                    switch (deep)
                    {
                        case 0:
                            childPos -= 8;
                            break;
                        case 1:
                            childPos -= 5;
                            break;
                        case 2:
                            childPos -= 2;
                            break;
                        case 3:
                            childPos -= 1;
                            break;
                    }
                    if (childPos >= 0)
                    {
                        Console.SetCursorPosition(childPos, level + 1);
                        Console.Write("\\");
                        while (curPos < childPos)
                        {
                            Console.SetCursorPosition(curPos, level);
                            Console.Write("_");
                            curPos++;
                        }
                        this.rightChild.treeOut(childPos + 1, level + 2, deep + 1);
                    }
                }
                /*
                Console.SetCursorPosition(offset, level);
                Console.Write(this.value);
                if (leftChild != null)
                {
                    //построение линии
                    int curPos = offset - 1; // от текущего значения
                    if (curPos < Console.WindowWidth / 2)   //для левых детей в левом поддереве
                    {
                        int childPos = offset / 2 + 1;   //до левого ребенка
                        Console.SetCursorPosition(childPos, level + 1);
                        Console.Write("/");

                        while (curPos > childPos)
                        {
                            Console.SetCursorPosition(curPos, level);
                            Console.Write("_");
                            curPos--;
                        }
                        this.leftChild.treeOut(offset / 2, level + 2);
                    }
                    else  //для левых детей в правом поддереве
                    {
                        int childPos = curPos - (Console.WindowWidth / 2 - offset / 2) + 2;   //до левого ребенка
                        Console.SetCursorPosition(childPos, level + 1);
                        Console.Write("/");

                        while (curPos > childPos)
                        {
                            Console.SetCursorPosition(curPos, level);
                            Console.Write("_");
                            curPos--;
                        }
                        this.leftChild.treeOut(childPos - 1, level + 2);
                    }
                }
                if (rightChild != null)
                {
                    int curPos = offset + 1; // от текуoего значения
                    if (curPos > Console.WindowWidth / 2)   //для правых детей в правом поддереве
                    {
                        int childPos = offset / 2 + Console.WindowWidth / 2 - 1;   //до правого ребенка
                        Console.SetCursorPosition(childPos, level + 1);
                        Console.Write("\\");
                        while (curPos < childPos)
                        {
                            Console.SetCursorPosition(curPos, level);
                            Console.Write("_");
                            curPos++;
                        }
                        this.rightChild.treeOut(offset / 2 + Console.WindowWidth / 2, level + 2);
                    }
                    else  //для правых детей в левом поддереве
                    {
                        int childPos = curPos + offset / 2 - 2;   //до правого ребенка
                        Console.SetCursorPosition(childPos, level + 1);
                        Console.Write("\\");

                        while (curPos < childPos)
                        {
                            Console.SetCursorPosition(curPos, level);
                            Console.Write("_");
                            curPos++;
                        }
                        this.rightChild.treeOut(childPos + 1, level + 2);
                    }
                }
                */
            }
        }
    }
}
