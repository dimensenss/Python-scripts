using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы
//заменить все предлоги не на слово «ГАВ!».
namespace Testing_Regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                str.Append(reader.ReadToEnd());
            }
            string _str = str.ToString();
            Console.WriteLine(_str);
            Console.WriteLine();
            Console.WriteLine(Regex.Replace(_str, @"\sне\s", " ГАВ! "));
            
            
            

        }
    }
}
