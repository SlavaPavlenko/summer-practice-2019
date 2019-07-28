using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree44
{
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
        public void treeOut(int offset, int level, int deep)  //offset - отступ слева, level - отступ сверху
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
                    case 3: childPos += 1;
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
            //Древний Код
            /*
            if (leftChild != null)
            {
                //построение линии
                int curPos = offset - 2; // от текущего значения
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
                int curPos = offset + 2; // от текуoего значения
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
