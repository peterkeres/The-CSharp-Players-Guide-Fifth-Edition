namespace Variable_Shop; // Note: actual namespace depends on the project name.

internal class Program
{
    static void Main(string[] args)
    {

        string str = "hello!";
        char ch = '\u1191';

        int num = 32;
        short num2 = 1;
        long num3 = 44444;
        uint num4 = 324;
        ushort num5 = 14;
        ulong num6 = 444445;

        byte by = 22;
        sbyte by2 = 44;
        
        float dec = 22.2f;
        double dec1 = 33.33;
        decimal dec2 = 44.44m;

        bool bo = true;

        
        
        Console.WriteLine(str);
        Console.WriteLine(ch);
        Console.WriteLine(num);
        Console.WriteLine(num2);
        Console.WriteLine(num3);
        Console.WriteLine(num4);
        Console.WriteLine(num5);
        Console.WriteLine(num6);
        Console.WriteLine(by);
        Console.WriteLine(by2);
        Console.WriteLine(dec);
        Console.WriteLine(dec1);
        Console.WriteLine(dec2);
        Console.WriteLine(bo);

    }
}