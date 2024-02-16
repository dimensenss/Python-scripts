using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_StringBilder_VS_String.Concat
{
    internal class Program
    {
        static void Main()
        {
        
            //StringBuilder
            string str = String.Empty;
            StringBuilder stringBuilder= new StringBuilder(str);
            var time1 = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                stringBuilder.Append("i");
            }
            str = stringBuilder.ToString();
            Console.WriteLine(DateTime.Now - time1);
            Console.WriteLine("Str Length {0}", str.Length);

            //+
            str = String.Empty;
            var time2 = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                str += "i";
            }
            Console.WriteLine(DateTime.Now - time2);
            Console.WriteLine("Str Length {0}",str.Length);

        }
    }
}
