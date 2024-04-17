using System.Runtime.CompilerServices;

namespace MyApp;

public static class RandomExtensions
{

    public static double NextDouble(this Random random, int maxValue)
    {
        return random.Next(maxValue) + random.NextDouble();
    }

    public static string NextString(this Random random ,params string[] strings)
    {
        return strings[random.Next(strings.Length)];
    }



    public static bool CoinFlip(this Random random, double rateOfTrue = .5)
    {
        double flip = random.NextDouble();
        return flip <= rateOfTrue ?  true : false ;
        
    }
    
    
    
}