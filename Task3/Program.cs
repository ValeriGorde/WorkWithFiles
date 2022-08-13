using System;
using System.IO;

namespace Task3
{
    internal class Program
    {
        const string dirName = @"D:\Валерия\SkillFactory";
        
        public static long DirSize(DirectoryInfo dir)
        {
            long size = 0;
            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (var f in files)
                {
                    size += f.Length;
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (var d in dirs)
                {
                    size += DirSize(d);
                }
                return size;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return size;

        }

        static void Main(string[] args)
        {
            long size = 0;
            if (Directory.Exists(dirName))
            {
                size = DirSize(new DirectoryInfo(dirName));
                Console.WriteLine("Исходный размер папки: {0} байт.", size);

            }
            TimeSpan interval = TimeSpan.FromMinutes(30);
            var currentTime = DateTime.Now;
            var timeSpan = TimeSpan.FromMinutes(30);
            try
            {
                int countFiles = 0;
                int countDirs = 0;

                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    var fileTime = file.LastAccessTime;
                    var difference = currentTime - fileTime;
                    if (difference > timeSpan)
                    {
                        file.Delete();
                        countFiles++;
                    }
                }
                Console.WriteLine("Количество удаленных файлов: {0}", countFiles);

                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    var dirTime = dir.LastAccessTime;
                    var difference = currentTime - dirTime;
                    if (difference > timeSpan)
                    {
                        dir.Delete(true);
                        countDirs++;
                    }
                }
                Console.WriteLine("Количество удалённых папок: {0}", countDirs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            long currentSize = DirSize(new DirectoryInfo(dirName));
            long freeSpace = size - currentSize;
            Console.WriteLine("Текущий размер папки: {0}", currentSize);
            Console.WriteLine("Освобождено: {0}", freeSpace);

        }
    }
}
