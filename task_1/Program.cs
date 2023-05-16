//Завдання 1.
// Файл містить 100000 цілих чисел. Додаток має проаналізувати файл і відобразити статистику по ньому: 
//1.Кількість додатних чисел. 
//2.Кількість від'ємних чисел. 
//3.Кількість двозначних чисел. 
//4.Кількість п'ятизначних чисел. Крім того, додаток має створити файли з цими числами (додатні, від'ємні і т. д.).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task_1
{
    internal class Program
    {
        static void FillArray(int[] arr, int size)
        {
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(-100000, 100000);
            }
        }
        static void WriteToFile(string path, int[] arr)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
                {
                    foreach (int item in arr)
                    {
                        bw.Write(item);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int size = 100000;
            int[] arr = new int[size];
            string path = "data.txt";

            FillArray(arr, size);

            WriteToFile(path, arr);
        }
    }
}
