using System;




public class Program
{ 
    public static void Divide(int a, int b, out int quotient, out int remainder)
    {
        quotient = a / b;
        remainder = a % b;
    }
    public static void Main(string[] args)
    {
        int x = 10;
        int y = 3;
        int result;

        Divide(x, y, out result, out int remainder);

        Console.WriteLine("Частное: " + result);
        Console.WriteLine("Остаток: " + remainder);
    }
}