using System;
using System.Net.Mime;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int test = AskForNumberInRange("welcome to the number grabber! please enter a number between 1 and 10", 1, 10);
            Console.WriteLine($"your input of {test} is a pass!");

        }



        static int AskForNumber(string text)
        {
            Console.WriteLine(text);
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }

        static int AskForNumberInRange(string text, int min, int max)
        {

            int userInput;
            
            do
            {
                userInput = AskForNumber(text);
                
            } while (userInput <= min || userInput >= max);


            return userInput;
        }
        
        
        
    }
}