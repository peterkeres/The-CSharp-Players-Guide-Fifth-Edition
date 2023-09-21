namespace Laws_of_Freach // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[] {4, 51, -7, 13, -99, 15, -8, 45, 90};


            int total = 0;
            int smallest = int.MaxValue;

            foreach (var value in array)
            {
                if (value < smallest)
                {
                    smallest = value;
                }
                total += value;
            }


            Console.WriteLine($"Smallest Value is {smallest}");
            float average = (float)total / array.Length;
            Console.WriteLine($"With an average of {average}");



        }
    }
}