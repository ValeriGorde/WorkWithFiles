using System;
using System.IO;

namespace Task2
{
    internal class Program
    {
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

            string dirName = @"D:\Валерия\SkillFactory";
            if (Directory.Exists(dirName))
            {
                long size = DirSize(new DirectoryInfo(dirName));
                Console.WriteLine("Размер папки: {0} байт.", size);

            }
        }
    }
}
