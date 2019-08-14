using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
Описать процедуру AddLineNumbers(S, N, K, L), добавляющую в на-
чало каждой строки существующего текстового файла с именем S ее по-
рядковый номер: первая строка получает номер N, вторая — N + 1 и т. д.
Номер отображается в K позициях, выравнивается по правому краю и от-
деляется от последующего текста L пробелами (K > 0, L > 0). Если строка
файла является пустой, то она также нумеруется, но пробелы после номера
не добавляются. Применить эту процедуру к данному файлу, используя
указанные значения N, K и L.
*/
namespace param51
{
    class Program
    {
        static void Main(string[] args)
        {
            addLineNumbers("C:\\Users\\SunRay\\Documents\\summer-practice-2019\\param51\\file.txt", 9, 3, 5);
        }
        public static void addLineNumbers(string S, int N, int K, int L)
        {
            string format = "{0," + K + ":0}";
            FileStream file1 = new FileStream(S, FileMode.Open);
            string tmpFilePath = Path.GetTempFileName();    //создается файл и возвращается полный путь к нему
            FileStream file2 = new FileStream(tmpFilePath, FileMode.Create);
            StreamReader reader = new StreamReader(file1, Encoding.Default);
            StreamWriter writer = new StreamWriter(file2, Encoding.Default);
            string str = reader.ReadLine();
            int i = N;
            while (str != null)
            {
                
                writer.Write(format, i++);
                for (int j = 0; j < L; j++)
                    writer.Write(" ");
                writer.WriteLine(str);
                str = reader.ReadLine();
            }
            writer.Close();
            reader.Close();
            file1.Close();
            File.Delete(S);
            File.Move(tmpFilePath, S);
        }
    }
}
