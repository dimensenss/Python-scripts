using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Threads
{
    class FileManager
    {
        private readonly Mutex _mutex = new Mutex();
        public void WriteToFile(string path)
        {
            Console.WriteLine("Thread id {0} starts", Thread.CurrentThread.Name);
            _mutex.WaitOne();

            File.WriteAllText(path, new StringBuilder().ToString());

            _mutex.ReleaseMutex();

            Console.WriteLine("Thread id {0} ends", Thread.CurrentThread.Name);
        }
        public void ReadFromFile(string path)
        {
            Console.WriteLine("Thread id {0} starts", Thread.CurrentThread.Name);
            _mutex.WaitOne();

            new StringBuilder().Append(File.ReadAllText(path));

            _mutex.ReleaseMutex();

            Console.WriteLine("Thread id {0} ends", Thread.CurrentThread.Name);
        }
    }
    class Program
    {
        static void Main()
        {
            File.WriteAllText("text1.txt", "info 1");

            File.WriteAllText("text2.txt", "info 2");

            Thread[] threads = {
               new Thread(() => new FileManager().ReadFromFile("text1.txt")),
               new Thread(() => new FileManager().ReadFromFile("text1.txt")),
               new Thread(() => new FileManager().ReadFromFile("text2.txt")),
               new Thread(() => new FileManager().WriteToFile("file3.txt"))
            };
            int i = 0;
            foreach (var thread in threads)
            {
                thread.Start();
                thread.Name = i.ToString();
                thread.Join();
                ++i;
            }


            //thread1.Join();
            //thread2.Join();


            Console.WriteLine("Main Thread ends");
        }
    }
}