using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int manticoreMaxHealth = 10, cityMaxHealth = 15, round = 0;
            int manticoreDistance = 0, cannonRange = 0, cannonDamange = 0;
            int manticoreCurrentHelth = manticoreMaxHealth, cityCurrentHealth = cityMaxHealth;
            bool didHit = false;


            manticoreDistance = GetManitcoreDistance();
            Console.Clear();
            Console.WriteLine("PLAYER 2: its your turn.");

            do
            {
                round++;
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"STATUS: Round: {round}  City: {cityCurrentHealth}/{cityMaxHealth}  Manticore: {manticoreCurrentHelth}/{manticoreMaxHealth}");
                cannonDamange = GetCannonDamage(round);
                cannonRange = GetCannonRange();
                didHit = GetDidHit(manticoreDistance, cannonRange);

                if (didHit) manticoreCurrentHelth -= cannonDamange;
                if (manticoreCurrentHelth > 0) cityCurrentHealth--;
                
                
            } while (manticoreCurrentHelth > 0 && cityCurrentHealth > 0);


            if (manticoreCurrentHelth  <= 0 && cityCurrentHealth <= 0)
            {
                Console.WriteLine("wow, both you and the Manticore died");
            }
            else if (manticoreCurrentHelth <= 0)
            {
                Console.WriteLine("The Manticore has been destroyed! the city of Consolas has been saved!");
            }
            else if (cityCurrentHealth <= 0)
            {
                Console.WriteLine("the city has been destroyed! the Manticore lives on");
            }
            

        }


        static bool GetDidHit(int manticorePos, int cannonPos)
        {

            if (manticorePos == cannonPos)
            {
                Console.Write("That round was a ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DIRECT HIT!");
                Console.ResetColor();
                return true;
            }
            else if (cannonPos > manticorePos)
            {
                Console.Write("That round ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("OVERSHOT ");
                Console.ResetColor();
                Console.WriteLine("of the target.");
            }
            else
            {
                Console.Write("That round ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("FELL SHORT ");
                Console.ResetColor();
                Console.WriteLine("of the target.");
            }

            return false;
        }

        static int GetCannonRange()
        {
            Console.Write("Enter desired cannon range: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        
        
        

        static int GetCannonDamage(int round)
        {
            int damage = 0;

            if (round % 3 == 0 && round % 5 == 0 )
            {
                damage = 10;
            }
            else if (round % 3 == 0 || round % 5 == 0)
            {
                damage = 3;
            }
            else
            {
                damage = 1;
            }

            Console.WriteLine($"The cannon is expected to deal {damage} this round.");

            return damage;

        }
        
        
        static int GetManitcoreDistance()
        {
            int userDistance = 0, upperRange = 100, lowerRange = 0;
            bool inRange = false;
            
            do
            {
                Console.Write("PLAYER 1: How far away from the city do you want to station the Manticore? ");
                userDistance = Convert.ToInt32(Console.ReadLine());

                if (userDistance <= upperRange && userDistance >= lowerRange)
                {
                    inRange = true;
                }
                else
                {
                    Console.WriteLine("That is outside the defined range, try again");
                }

            } while (!inRange);
            
            return userDistance;
        }
        
        
        
        
    }
}