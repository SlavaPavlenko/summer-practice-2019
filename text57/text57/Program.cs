using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Посчитать в файле кол-во строчных русских букв и вывести их в другой файл

namespace text57
{
    public class Pare
    {
        public char Letter { get; set; }
        public int Amount { get; set; }

        public Pare(char letter, int amount)
        {
            Letter = letter;
            Amount = amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream("C:\\Users\\SunRay\\Documents\\summer-practice-2019\\text57\\input.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file, Encoding.Default);
            List<Pare> list = new List<Pare>();
            char symbol = (char)reader.Read();
            while (symbol != '\uffff')
            {
                if (symbol >= 'а' && symbol <= 'я')
                {
                    Pare pare = list.Find(x => x.Letter == symbol);
                    if (pare == null)
                    {
                        Pare tmp = new Pare(symbol, 1);
                        list.Add(tmp);
                    }
                    else pare.Amount++;
                }
                symbol = (char)reader.Read();
            }
            reader.Close();
            file.Close();

            file = new FileStream("C:\\Users\\SunRay\\Documents\\summer-practice-2019\\text57\\output.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            var sortedList = list.OrderBy(pare=>pare.Letter);
            foreach (Pare pare in sortedList)
            {
                writer.WriteLine(pare.Letter + "-" + pare.Amount);
            }
            writer.Close();
            file.Close();
        }
    }
}
