using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Задание 2
//Создайте файл, запишите в него произвольные данные и закройте файл. Затем снова откройте
//этот файл, прочитайте из него данные и выведете их на консоль. 
namespace _003
{
    internal class Program
    {
        static void Main()
        {
            #region exp1
            var file = new FileStream("text.txt", FileMode.OpenOrCreate);
            var writer = new StreamWriter(file);
            writer.WriteLine("some text");
            writer.Close();

            file = new FileStream("text.txt", FileMode.Open);
            var reader = new StreamReader(file);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            #endregion

            #region exp2
            File.WriteAllText("text1.txt", "some text");
            Console.WriteLine(File.ReadAllText("text1.txt"));
            #endregion
        }
    }
}
