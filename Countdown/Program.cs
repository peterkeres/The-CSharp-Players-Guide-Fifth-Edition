using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting countdown from 10!");
            CountdownFrom(10);
        }


        static void CountdownFrom(int number)
        {
            Console.WriteLine($"{number}");
            int newNumber = number - 1;

            if (number <= 0)
            {
                return;
            }
            CountdownFrom(newNumber);
        }
        
        
        
        
    }
}