using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    public static class Kata
    {
        public static string Order(string words)
        {
            string[] array_words = words.Split(' ');
            string[] new_string = new string[array_words.Length];

            var regex = new Regex(@"\d");
            foreach (string word in array_words)
            {
                if (regex.IsMatch(word))
                {
                    var match = regex.Match(word);
                    int digit = Int32.Parse(match.Value) - 1;
                    new_string[digit] = word;
                }
            }
            words = string.Join(" ", new_string);
            return words;
            throw new NotImplementedException();
        }

        public static string NewOrder(string words)
        {
            string[] array_words = words.Split(' ');
            return string.Join(" ", array_words.OrderBy(s => Regex.Match(s, @"\d+").Value));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.Order("is2 Thi1s T4est 3a"));
            Console.WriteLine(Kata.NewOrder("is2 Thi1s T4est 3a"));
            
        }
    }
}
