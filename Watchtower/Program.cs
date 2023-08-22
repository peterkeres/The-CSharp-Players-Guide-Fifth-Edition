namespace Watchtower // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int userX, userY;

            Console.Write("Please enter X value: ");
            userX = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Please enter Y value: ");
            userY = Convert.ToInt32(Console.ReadLine());

            string enemyPlacment = "";

            if (userX < 0 && userY > 0)
            {
                enemyPlacment = "in the NW";
            }
            else if (userX == 0 && userY > 0)
            {
                enemyPlacment = "in the N";
            }
            else if (userX > 0 && userY > 0)
            {
                enemyPlacment = "in the NE";
            }
            else if (userX < 0 && userY == 0)
            {
                enemyPlacment = "in the W";
            }
            else if (userX == 0 && userY == 0)
            {
                enemyPlacment = "Here";
            }
            else if (userX > 0 && userY == 0)
            {
                enemyPlacment = "in the E";
            }
            else if (userX < 0 && userY < 0)
            {
                enemyPlacment = "in the SW";
            }
            else if (userX == 0 && userY < 0)
            {
                enemyPlacment = "in the S";
            }
            else if (userX > 0 && userY < 0)
            {
                enemyPlacment = "in the SE";
            }

            Console.WriteLine($"The enemy is {enemyPlacment}");
            



        }
    }
}