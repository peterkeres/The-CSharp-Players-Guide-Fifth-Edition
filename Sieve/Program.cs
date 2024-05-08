using System;
using System.Diagnostics;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("What Filter do you want?" +
                              "\n1: even" +
                              "\n2: positive" +
                              "\n3: multiple");
            int userPick = Convert.ToInt32(Console.ReadLine());

            Sieve sieve = null;
            string currentFilter = "";

            if (userPick == 1)
            {
                sieve = new Sieve(IsEven);
                currentFilter = "Is Even";
            }

            if (userPick == 2)
            {
                currentFilter = "Is Postive";
                sieve = new Sieve(IsPostive);
            }

            if (userPick == 3)
            {
                currentFilter = "Is Multiple";
                sieve = new Sieve(IsMultipleOfTen);
            }

            do
            {
                Console.WriteLine($"Current Filter {currentFilter}");
                Console.WriteLine("Enter a number");
                Console.WriteLine(sieve?.IsGood(Convert.ToInt32(Console.ReadLine())));

            } while (true);

        }
        
        public static bool IsEven(int number)
        {
            return number % 2 == 0 ?  true :  false;
        }

        public static bool IsPostive(int number)
        {
            return number >= 1 ? true : false;
        }

        public static bool IsMultipleOfTen(int number)
        {
            return number % 10 == 0 ? true : false;
        }
        
        
        
    }


    class Sieve
    {
        private Func<int, bool> filter;

        public Sieve(Func<int, bool> filter)
        {
            this.filter = filter;
        }

        public bool IsGood(int number)
        {
            return filter.Invoke(number);
        }
    }



    
    
}