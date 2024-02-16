using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Напишите приложение для поиска заданного файла на диске. Добавьте код, использующий
//класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
//добавьте возможность сжатия найденного файла.
namespace _003_2
{
    static class CheckFile
    {
        private static DirectoryInfo dir =new DirectoryInfo(@".");

        public static void CreateFiles()
        {
            dir.CreateSubdirectory("files");
            if (dir.Exists)
            {
                var rand = new Random();
                for (int i = 0; i < 100; i++)
                {
                    if (rand.Next(1, 3)>1)
                    {
                        using (var writer = new StreamWriter($@"files\file{i}.txt"))
                        {
                            writer.WriteLine("gold");
                        }
                    }
                    else
                    {
                        using (var writer = new StreamWriter($@"files\file{i}.txt"))
                        {
                            writer.WriteLine("nothing");
                        }
                    }
                }
            }
        }

        public static void Check() 
        {
            var files = dir.GetFiles(@"files/*.txt");
            dir.CreateSubdirectory("files with gold");
            foreach (var file in files)
            {
                using (var reader = new StreamReader($@"files\{file}"))
                {
                    string str = reader.ReadToEnd();
                    if (str.Contains("gold"))
                    {
                        using (var writer = new StreamWriter($@"files with gold\{file}"))
                        {
                            writer.WriteLine(str);
                        }
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckFile.CreateFiles();
            CheckFile.Check();

        }
    }
}
