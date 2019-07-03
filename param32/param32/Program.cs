using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Преобразование прописных русских букв в заглавные

namespace param32
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Я не совсем еще рассудок потерял";
            string s2 = "От рифм бахических — шатаясь на Пегасе —";
            string s3 = "Ya ne zabil sebya, hot' rad, hotya ne rad.";
            string s4 = "Нет, нет — вы мне совсем не брат:";
            string s5 = "Вы дядя мне и на Парнасе.";
            Console.WriteLine(UpCaseRus(s1));
            Console.WriteLine(UpCaseRus(s2));
            Console.WriteLine(UpCaseRus(s3));
            Console.WriteLine(UpCaseRus(s4));
            Console.WriteLine(UpCaseRus(s5));
            Console.Read();
        }
        public static string UpCaseRus(string S)
        {
            int i = 0;
            while (i < S.Length)
            {
                if (S[i] >= 'а' && S[i] <= 'я')
                {
                    Char c = Char.ToUpper(S[i]);
                    S = S.Remove(i, 1).Insert(i, c.ToString());
                }
                i++;
            }
            return S;
        }
    }
}
