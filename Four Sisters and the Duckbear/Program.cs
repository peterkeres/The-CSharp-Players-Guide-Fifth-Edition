namespace Four_Sisters_and_the_Duckbear; // Note: actual namespace depends on the project name.



internal class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter in the number of eggs gathered for the day:");
        int numberOfEggs = Convert.ToInt32(Console.ReadLine());

        int eggsForGirls = numberOfEggs / 3;
        int eggsForDuckbear = numberOfEggs % 3;

        Console.WriteLine($"Each girl should get {eggsForGirls} eggs.");
        Console.WriteLine($"Duckbear should get {eggsForDuckbear} eggs.");


    }
}