namespace Potion_Masters_of_Pattern;

class Program
{
    static void Main(string[] args)
    {
        Potion userPotion = new Potion(PotionType.Water);
        IngredientType? userIngredient;

        do
        {
            Console.Out.WriteLine($"You currently have a {userPotion.PotionType} potion.");


            Console.Out.WriteLine("do you want to add anything? (y/n)");
            if (Console.ReadLine().ToLower() == "n") { break; }
            
            Console.Out.WriteLine("Following ingredients are available:");
            foreach (var ingredient in Enum.GetNames<IngredientType>())            
            {
                Console.WriteLine(ingredient);
            }

            userIngredient = Console.ReadLine() switch
            {
                "Stardust" => IngredientType.Stardust,
                "SnakeVenom" => IngredientType.SnakeVenom,
                "Breath" => IngredientType.DragonBreath,
                "ShadowGlass" => IngredientType.ShadowGlass,
                "EyeShine" => IngredientType.EyeShine,
                _ => throw new ArgumentOutOfRangeException()
            };
        
            userPotion = (userIngredient, userPotion.PotionType) switch
            {
                (IngredientType.Stardust , PotionType.Water) => new Potion(PotionType.Elixir),
                (IngredientType.SnakeVenom , PotionType.Elixir) => new Potion(PotionType.Poison),
                (IngredientType.DragonBreath , PotionType.Elixir) => new Potion(PotionType.Flying),
                (IngredientType.ShadowGlass , PotionType.Elixir) => new Potion(PotionType.Invisibility),
                (IngredientType.EyeShine , PotionType.Elixir) => new Potion(PotionType.NightSight),
                (IngredientType.ShadowGlass , PotionType.NightSight) => new Potion(PotionType.Cloudy),
                (IngredientType.EyeShine , PotionType.Invisibility) => new Potion(PotionType.Cloudy),
                (IngredientType.Stardust , PotionType.Cloudy) => new Potion(PotionType.Wraith),
                _ => new Potion(PotionType.Ruined),
            };

            if (userPotion.PotionType is PotionType.Ruined)
            {
                Console.Out.WriteLine("Ruined Potion!!! lets start over");
                userPotion = new Potion(PotionType.Water);
            }
            
        } while (true);

        Console.Out.WriteLine($"you ended up with a {userPotion.PotionType} potion.");

    }


    
    
    private record Potion(PotionType PotionType);
    enum PotionType {Water,Elixir, Poison, Flying, Invisibility,NightSight, Cloudy, Wraith, Ruined }
    enum IngredientType {Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeShine}
}