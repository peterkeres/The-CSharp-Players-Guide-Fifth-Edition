namespace Simulas_Soup // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            (Food Food, MainIngredient ingredient, Seasoning seasoning) userSoup = (Food.Gumbo,MainIngredient
                .Carrots,Seasoning.Salty);
            (bool gotFood, bool gotIngredient, bool gotSeasoning) gotUserChocies = (false,false,false);
            
            do
            {
                
                Console.Out.WriteLine("Please pick the Type of stew:");
                Console.Out.WriteLine($"\t{Food.Soup}");
                Console.Out.WriteLine($"\t{Food.Stew}");
                Console.Out.WriteLine($"\t{Food.Gumbo}");

                string user = Console.ReadLine().ToLower();

                if (user == Food.Soup.ToString().ToLower())
                {
                    userSoup.Food = Food.Soup;
                    gotUserChocies.gotFood = true;
                }
                else if (user == Food.Gumbo.ToString().ToLower())
                {
                    userSoup.Food = Food.Gumbo;
                    gotUserChocies.gotFood = true;
                }
                else if (user == Food.Stew.ToString().ToLower())
                {
                    userSoup.Food = Food.Stew;
                    gotUserChocies.gotFood = true;
                }
                else
                {
                    Console.Out.WriteLine("Sorry not an option, please pick again");
                }


            } while (!gotUserChocies.gotFood);
            
            do
            {
                
                Console.Out.WriteLine("Please pick the ingredient:");
                Console.Out.WriteLine($"\t{MainIngredient.Carrots}");
                Console.Out.WriteLine($"\t{MainIngredient.Chicken}");
                Console.Out.WriteLine($"\t{MainIngredient.Mushrooms}");
                Console.Out.WriteLine($"\t{MainIngredient.Potatoes}");

                string user = Console.ReadLine().ToLower();

                if (user == MainIngredient.Carrots.ToString().ToLower())
                {
                    userSoup.ingredient = MainIngredient.Carrots;
                    gotUserChocies.gotIngredient = true;
                }
                else if (user == MainIngredient.Chicken.ToString().ToLower())
                {
                    userSoup.ingredient = MainIngredient.Chicken;
                    gotUserChocies.gotIngredient = true;
                }
                else if (user == MainIngredient.Mushrooms.ToString().ToLower())
                {
                    userSoup.ingredient = MainIngredient.Mushrooms;
                    gotUserChocies.gotIngredient = true;
                }
                else if (user == MainIngredient.Potatoes.ToString().ToLower())
                {
                    userSoup.ingredient = MainIngredient.Potatoes;
                    gotUserChocies.gotIngredient = true;
                }
                else
                {
                    Console.Out.WriteLine("Sorry not an option, please pick again");
                }


            } while (!gotUserChocies.gotIngredient);
            
            do
            {
                
                Console.Out.WriteLine("Please pick the Type of seasoning:");
                Console.Out.WriteLine($"\t{Seasoning.Salty}");
                Console.Out.WriteLine($"\t{Seasoning.Spicy}");
                Console.Out.WriteLine($"\t{Seasoning.Sweet}");

                string user = Console.ReadLine().ToLower();

                if (user == Seasoning.Salty.ToString().ToLower())
                {
                    userSoup.seasoning = Seasoning.Salty;
                    gotUserChocies.gotSeasoning = true;
                }
                else if (user == Seasoning.Spicy.ToString().ToLower())
                {
                    userSoup.seasoning = Seasoning.Spicy;
                    gotUserChocies.gotSeasoning = true;
                }
                else if (user == Seasoning.Sweet.ToString().ToLower())
                {
                    userSoup.seasoning = Seasoning.Sweet;
                    gotUserChocies.gotSeasoning = true;
                }
                else
                {
                    Console.Out.WriteLine("Sorry not an option, please pick again");
                }


            } while (!gotUserChocies.gotSeasoning);



            Console.Out.WriteLine($"Great! your soup is {userSoup}");

        }
        


        enum Food
        {
            Soup,Stew,Gumbo
        }

        enum MainIngredient
        {
            Mushrooms,Chicken,Carrots,Potatoes
        }

        enum Seasoning
        {
            Spicy,Salty,Sweet
        }
        
        
    }
}