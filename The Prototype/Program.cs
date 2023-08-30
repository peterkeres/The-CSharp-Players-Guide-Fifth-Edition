using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int user1 , user2 ;


            do
            {
                Console.Write("User 1, Enter a number between 0 and 100: ");
                user1 = Convert.ToInt32(Console.ReadLine());
                

                if (user1 <=0 || user1 >= 100)
                {
                    Console.WriteLine($"Nope, {user1} isnt in the range im looking for");
                }
                
            } while (user1 <=0 || user1 >= 100);


            Console.Clear();
            Console.WriteLine("User 2, guess the number.");
            
            do
            {
                Console.Write("What is your guess? ");
                user2 = Convert.ToInt32(Console.ReadLine());

                if (user2 > user1)
                {
                    Console.WriteLine($"{user2} was too high.");
                }
                else if (user2 < user1)
                {
                    Console.WriteLine($"{user2} was too low.");
                }
                
            } while (user1 != user2);

            Console.WriteLine("you guessed the number!");
            

        }
    }
}