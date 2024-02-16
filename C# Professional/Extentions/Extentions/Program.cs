using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Extentions
{

    static class Myclass
    {

        public static Func<T, R> memFunc<T, R>(this Func<T, R> newFunc)
        {
            var cache = new Dictionary<T, R>();
            return x =>
            {
                R result = default;

                if (cache.TryGetValue(x, out result))
                    return result;

                result = newFunc(x);
                cache[x] = result;
                return result;
            };
        }
    }

    static class Program
    {
        public static int fib(int x)
        {
            return x > 1 ? fib(x - 1) + fib(x - 2) : x;
        }


        static void Main(string[] args)
        {
            Func<int, int> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            fib = fib.memFunc();

            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("{0}, {1}", i, fib(i));
            }
        }
    }
}
