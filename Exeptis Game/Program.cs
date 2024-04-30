
using System.Net;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int oatmealCookie = rand.Next(0,10);
            Console.WriteLine("the oatmeal is: " + oatmealCookie);

            try
            {
                cookieGuesser(oatmealCookie);
            }
            catch (CookieException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("i think its funny throwing a cookie execption ^_^");
            }



        }

        static void cookieGuesser(int oatmealCookie)
        {
            List<int> userGuessHistory = new List<int>();
            int userGuess;
            
            do
            {
                Console.WriteLine("pick a number between 0 and 9");
                userGuess = Convert.ToInt32(Console.ReadLine());

                if (userGuessHistory.Contains(userGuess) && userGuess != oatmealCookie)
                {
                    Console.WriteLine("already did that number, try again");
                }
                
                if (!userGuessHistory.Contains(userGuess) && userGuess != oatmealCookie)
                {
                    userGuessHistory.Add(userGuess);
                }


            } while (userGuess != oatmealCookie);


            throw new CookieException();
            
            
            
        }
    }
}