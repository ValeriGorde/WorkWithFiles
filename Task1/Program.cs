using System;
using System.IO;

namespace Task1
{
    internal class Program
    {
        const string dirName = @"D:\Валерия\SkillFactory";
        public static void DeleteInDir() 
        {
            TimeSpan interval = TimeSpan.FromMinutes(30);
            var currentTime = DateTime.Now;
            var timeSpan = TimeSpan.FromMinutes(30);
            try
            {

                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    var fileTime = file.LastAccessTime;
                    var difference = currentTime - fileTime;
                    if (difference > timeSpan)
                    {
                        file.Delete();
                        Console.WriteLine("Файл удалён.");
                    }
                    else
                    {
                        Console.WriteLine("Файл не удалён. Время последнего использования файла: {0}", fileTime);
                    }
                }

                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    var dirTime = dir.LastAccessTime;
                    var difference = currentTime - dirTime;
                    if (difference > timeSpan)
                    {
                        dir.Delete();
                        Console.WriteLine("Папка удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Папка не удалена. Время последнего использования папки: {0}", dirTime);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {

            if (Directory.Exists(dirName)) 
            {
                Console.WriteLine("Директория существует!");
                Console.WriteLine("Папки: ");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string d in dirs) 
                {
                    Console.WriteLine(d);
                }

                Console.WriteLine("Файлы");
                string[] files = Directory.GetFiles(dirName);
                foreach (string f in files) 
                {
                    Console.WriteLine(f);
                }
            }
            DeleteInDir();

        }
    }
}
