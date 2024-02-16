using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parelel_foreach
{
    internal class Program
    {
        static void DisplayNumbers(int num)
        {
            //Console.WriteLine(num);
        }

        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            var data = new int[1000];
            int j = 0;
            timer.Start();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = j++;
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);
            timer.Reset();

            timer.Start();
            Parallel.ForEach(data, DisplayNumbers);
            timer.Stop();
            Console.WriteLine("parelel {0}", timer.Elapsed.TotalMilliseconds);
            timer.Reset();

            timer.Start();
            foreach (var i in data)
            {
                Console.WriteLine(i);
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);
        }
    }
}