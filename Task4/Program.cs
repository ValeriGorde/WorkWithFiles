using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{   
    internal class Program
    { 
       
        static void Main(string[] args)
        {
            string dirName = @"D:\раб стол\_Students.dat";
            string nameValue;
            string groupValue;
            string dateBirth;

            using (BinaryReader br = new BinaryReader(File.Open(dirName, FileMode.Open)))
            {
                nameValue = br.ReadString();
                groupValue = br.ReadString();
                dateBirth = br.ReadString();
            }
            Console.WriteLine("Имя: {0}", nameValue);
            Console.WriteLine("Группа: {0}", groupValue);
            Console.WriteLine("Дата рождения: {0}", dateBirth);

            Student student = new Student(nameValue, groupValue, dateBirth);

            DirectoryInfo dirInfo = new DirectoryInfo(@"D:\раб стол");
            if (dirInfo.Exists) 
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory("NewFolder");

            string fileName = @$"D:\раб стол\NewFolder\{groupValue}";
            if (!File.Exists(fileName)) 
            {
                using (StreamWriter sw = File.CreateText(fileName)) 
                {
                    sw.WriteLine($"Имя: {nameValue}");
                    sw.WriteLine($"Дата рождения: {dateBirth}");
                }
            }

            Console.ReadKey();
        }
    }
}
