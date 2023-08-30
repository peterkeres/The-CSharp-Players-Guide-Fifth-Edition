using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {


            for (int i = 1; i <= 100; i++)
            {


                string gem;

                
                if (i % 5 == 0 && i % 3 == 0)
                {
                    gem = "Fire and Electric";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (i % 3 == 0)
                {
                    gem = "Fire";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (i % 5 == 0)
                {
                    gem = "Electric";
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    gem = "normal";
                    Console.ResetColor();
                }

                
                Console.WriteLine($"{i}: {gem}");



            }
            
            
            
            
            
            
        }
    }
}