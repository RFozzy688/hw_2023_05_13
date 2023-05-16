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
        static void Main(string[] args)
        {
            string str = null;

            ReadFromFile("data.txt", ref str);

            Console.WriteLine(str);
        }
    }
}
