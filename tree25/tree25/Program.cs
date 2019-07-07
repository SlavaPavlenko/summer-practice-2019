using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree25
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int N = Convert.ToInt32(Console.ReadLine());
            if (N == 0)
                Console.WriteLine("Неверное значение");
            else
            {
                int[] mas = new int[N];
                for (int i = 0; i < N; i++)
                {
                    mas[i] = random.Next();
                }
            }
            Console.Read();

        }
    }
}
