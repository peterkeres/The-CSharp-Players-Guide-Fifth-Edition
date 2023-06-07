namespace Triangle_Farmer; // Note: actual namespace depends on the project name.

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the base: ");
        int baseInput = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the height: ");
        int heightInput = Convert.ToInt32(Console.ReadLine());

        int area = (baseInput * heightInput) / 2;
        
        Console.WriteLine($"The area of the triangle is {area}");

    }
}