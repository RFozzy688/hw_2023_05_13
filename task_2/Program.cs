//Завдання 2.
//Користувач вводить з клавіатури слово для пошуку у файлі, шлях до файлу і слово для заміни. 
//Додаток має змінити усі входження шуканого слова на слово для заміни. Статистику роботи додатку виведіть на екран.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Program
    {
        static void ReadFromFile(string path, ref string str)
        {
            using(var sr = new StreamReader(path))
            {
                str = sr.ReadToEnd();
            }
        }
        static void WriteToFile(string path, string str)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(str);
            }
        }
        static void Main(string[] args)
        {
            string str = null;
            string findWord = null;
            string replaceWord = null;
            char[] separators = { ',', ' ', '.', '-' };
            string path = "..\\..\\data.txt";
            int count = 0;

            ReadFromFile(path, ref str);

            Console.Write("Найти: ");
            findWord = Console.ReadLine();
            Console.Write("Заменить: ");
            replaceWord = Console.ReadLine();

            string[] words = str.Split(separators);

            foreach(string word in words)
            {
                if (word.Contains(findWord))
                {
                    count++;
                }
            }

            str = str.Replace(findWord, replaceWord);

            WriteToFile(path, str);

            Console.WriteLine($"Количество замененных слов: {count}");
        }
    }
}
