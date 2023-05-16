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
        static void FillArray(int[] arr)
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100000, 100000);
            }
        }
        static void WriteToFile(string path, int[] arr)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs, Encoding.ASCII))
                {
                    foreach (int item in arr)
                    {
                        bw.Write(item);
                    }
                }
            }
        }
        static void ReadFromFile(string path, ref int[] arr)
        {
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                arr = new int[fs.Length / 4];
                int count = 0;

                using(BinaryReader br = new BinaryReader(fs, Encoding.ASCII))
                {
                    while(count != fs.Length / 4)
                    {
                        arr[count++] = br.ReadInt32();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int size = 100000;
            int[] arr = new int[size];
            string path = "data.txt";

            FillArray(arr);

            WriteToFile(path, arr);

            int[] newArr = null;

            ReadFromFile(path, ref newArr);

            foreach (int item in newArr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
