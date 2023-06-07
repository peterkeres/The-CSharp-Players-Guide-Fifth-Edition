namespace Thing_Namer_3000; // Note: actual namespace depends on the project name.



internal class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("What kind a of thing are we talking about?");
        string a = Console.ReadLine();      // Stores what is the item
        Console.WriteLine("How would you describe it?  Big? Azure? tattered?");
        string b = Console.ReadLine();      // Stores a description about the item
        string c = " of Doom";               // sub title about item
        string d = "3000";                  // version number of item
        Console.WriteLine("The " + b + " "  + a + c + " " + d + "!");


    }
}