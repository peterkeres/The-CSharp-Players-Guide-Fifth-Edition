using System.Net;

namespace Long_Game;

class Program
{
    static void Main(string[] args)
    {
        string? userName, fileName;
        int currentScore = 0;
        int pointPerKey = 1;
        
        Console.Out.WriteLine("Welcome to long game, please enter your name:");
        userName = Console.ReadLine();
        fileName = $"{userName}.txt";
        
        if (File.Exists(fileName))
        {
            string scoreFromFile =  File.ReadAllText(fileName);
            currentScore = Convert.ToInt32(scoreFromFile);
            Console.Out.WriteLine($"Welcome back {userName}, your starting score is {currentScore}");
        }
        else
        {
            Console.Out.WriteLine($"Hello {userName}, your score is {currentScore}");
        }
        
        
        
        Console.Out.WriteLine("Enter keys, press enter to quit");
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            currentScore += pointPerKey;
            Console.Out.WriteLine($"\nnew score: {currentScore}");
        }
        
        
        FileStream stream = new FileStream(fileName, FileMode.Create);
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(currentScore);
        Console.Out.WriteLine($"max score is {currentScore}, saved to file: {fileName}");
        
        writer.Close();

        
    }
    
    
    
    
}