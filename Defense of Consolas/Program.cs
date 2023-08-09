namespace Defense_of_Consolas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int row, column;
            Console.Title = "Defense of Consolas";

            Console.Write("Target Row? ");
            row = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Target Column? ");
            column = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Deploy to:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"({row},{column-1})\n" +
                              $"({row-1},{column})\n" +
                              $"({row},{column+1})\n" +
                              $"({row+1},{column})");
            
            Console.Beep();
            
                

        }
    }
}