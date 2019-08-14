using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace text43
{
    class Program
    {
        static void Main(string[] args)
        {
            bool error = false;
            double a = 0;
            double b = 0;
            int n = 0;
            try
            {
                Console.Write("a: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("b: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("n: ");
                n = Convert.ToInt16(Console.ReadLine());
                if (a >= b || n <= 0)
                    throw new System.FormatException();
            }
            catch (Exception e)
            {
                error = true;
                Console.WriteLine(e.Message);
            }
            if (!error)
            {
                FileStream file = new FileStream("C:\\Users\\SunRay\\Documents\\summer-practice-2019\\text43\\file.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(file);
                double x = a;
                writer.WriteLine(String.Format("{0,8:0.#}", "x") + String.Format("{0,12:0.#}",
                        "sin") + "\t" + String.Format("{0,12:0.#}", "cos"));
                while (x <= b)
                {
                    writer.WriteLine(String.Format("{0,8:0.#}", x) + String.Format("{0,12:0.#}",
                        Math.Sin(x)) + "\t" +String.Format("{0,12:0.#}", Math.Cos(x)));
                    x += (b-a)/n;
                }
                writer.Close();
                file.Close();
            }
            Console.Read();
        }
    }
}
