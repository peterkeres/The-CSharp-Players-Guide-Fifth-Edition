namespace Buying_Inventory // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string menu = "1 - Rope\n" +
                          "2 - Torches\n" +
                          "3 - Climbing Equipment\n" +
                          "4 - Clean Water\n" +
                          "5 - Machete\n" +
                          "6 - Canoe\n" +
                          "7 - Food Supplies";
            int userChoice = -1, itemPrice = -1;
            string itemName = "";
            
            
            Console.WriteLine(menu);
            Console.Write("What number do you want to see the price of? ");
            userChoice = Convert.ToInt32(Console.ReadLine());


            switch (userChoice)
            {
                case 1:
                    itemPrice = 10;
                    itemName = "Rope";
                    break;
                case 2:
                    itemPrice = 15;
                    itemName = "Torches";
                    break;
                case 3:
                    itemPrice = 25;
                    itemName = "Climbing Equipment";
                    break;
                case 4:
                    itemPrice = 1;
                    itemName = "Clean Water";
                    break;
                case 5:
                    itemPrice = 20;
                    itemName = "Machete";
                    break;
                case 6:
                    itemPrice = 20;
                    itemName = "Canoe";
                    break;
                case 7:
                    itemPrice = 1;
                    itemName = "Food Supplies";
                    break;
            }


            Console.WriteLine($"{itemName} costs {itemPrice} gold");





        }
    }
}