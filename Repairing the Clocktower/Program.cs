namespace Repairing_the_Clocktower // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please enter a number: ");
            int userNumber = Convert.ToInt32(Console.ReadLine());


            bool isEven = (userNumber % 2) == 0;

            if (isEven)
            {
                Console.WriteLine("Tick");
            }
            else
            {
                Console.WriteLine("Tock");
            }


        }
    }
}