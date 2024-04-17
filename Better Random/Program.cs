using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random random = new Random();
            
            
            Console.WriteLine($"Double is : {random.NextDouble(9)}");
            Console.WriteLine($"The next string is : {random.NextString("testing", "help", "cool")}");
            Console.WriteLine($"the coin flip is : {random.CoinFlip(.7)}");
        }
    }
}