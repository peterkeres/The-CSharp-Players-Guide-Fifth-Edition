namespace Dominion_of_Kings; // Note: actual namespace depends on the project name.



internal class Program
{
    static void Main(string[] args)
    {

        int estateValue = 1, duchyValue = 3, provinceValue = 6;

        int melikEstateTotal, melikDuchyTotal, melikProvinceTotal;
        int casikEstateTotal, casikDuchyTotal, casikProvinceTotal;
        int balikEstateTotal, balikDuchyTotal, balikProvinceTotal;


        Console.WriteLine("Please enter the number of lands for Melik");
        Console.Write("For Estates: ");
        melikEstateTotal = Convert.ToInt32(Console.ReadLine());
        Console.Write("For Duchy's: ");
        melikDuchyTotal = Convert.ToInt32(Console.ReadLine());
        Console.Write("For Provinces: ");
        melikProvinceTotal = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Please enter the number of lands for Casiks");
        Console.Write("For Estates: ");
        casikEstateTotal = Convert.ToInt32(Console.ReadLine());
        Console.Write("For Duchy's: ");
        casikDuchyTotal = Convert.ToInt32(Console.ReadLine());
        Console.Write("For Provinces: ");
        casikProvinceTotal = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Please enter the number of lands for Balik");
        Console.Write("For Estates: ");
        balikEstateTotal = Convert.ToInt32(Console.ReadLine());
        Console.Write("For Duchy's: ");
        balikDuchyTotal = Convert.ToInt32(Console.ReadLine());
        Console.Write("For Provinces: ");
        balikProvinceTotal = Convert.ToInt32(Console.ReadLine());

        
        int melikGrandTotal = (melikEstateTotal * estateValue) + 
                              (melikDuchyTotal * duchyValue) +
                              (melikProvinceTotal * provinceValue);
        
        int casikGrandTotal = (casikEstateTotal * estateValue) + 
                              (casikDuchyTotal * duchyValue) +
                              (casikProvinceTotal * provinceValue);
        
        int balikGrandTotal = (balikEstateTotal * estateValue) + 
                              (balikDuchyTotal * duchyValue) +
                              (balikProvinceTotal * provinceValue);
        

        Console.WriteLine($"Melik has {melikEstateTotal} Estates, {melikDuchyTotal} Duchy's, and {melikProvinceTotal} Provinces for grand total of: {melikGrandTotal}");
        Console.WriteLine($"Melik has {casikEstateTotal} Estates, {casikDuchyTotal} Duchy's, and {casikProvinceTotal} Provinces for grand total of: {casikGrandTotal}");
        Console.WriteLine($"Melik has {balikEstateTotal} Estates, {balikDuchyTotal} Duchy's, and {balikProvinceTotal} Provinces for grand total of: {balikGrandTotal}");
        
        




    }
}