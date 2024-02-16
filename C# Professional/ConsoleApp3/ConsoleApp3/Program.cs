using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Arge
    {

        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int n = 0;
            double per = percent / 100;
            do
            {
                p0 = (int)(p0 + p0 * per + aug);
                n++;
            } while (p0 <= p);
            return n;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Arge.NbYear(1000, 2, 50, 1200));
           
        }
    }
}
