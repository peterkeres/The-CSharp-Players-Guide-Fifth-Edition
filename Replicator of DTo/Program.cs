namespace Replicator_of_DTo // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int[] array1 = new int[5];
            int[] array2 = new int[array1.Length];


            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine("Please Enter a number");
                array1[i] = Convert.ToInt32(Console.ReadLine());
            }


            for (int i = 0; i < array1.Length; i++)
            {
                array2[i] = array1[i];
            }


            Console.WriteLine("Show off arrays");
            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine($"Value {i+1}: array1 = {array1[i]} , array2 = {array2[i]}");
            }



        }
    }
}