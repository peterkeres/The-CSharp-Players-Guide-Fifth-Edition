namespace War_Preparations // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Sword basicSword = new Sword(MaterialType.Iron, null, 2.2f, 1.1f);
            Sword swordV2 = basicSword with {GemstoneType = GemstoneType.Diamond, Length = 10.0f};
            Sword swordV3 = basicSword with {GemstoneType = GemstoneType.Bitstone, MaterialType = MaterialType.Binarium};


            Console.WriteLine(basicSword);
            Console.WriteLine(swordV2);
            Console.WriteLine(swordV3);


        }
    }






    record Sword(MaterialType MaterialType, GemstoneType? GemstoneType, float Length, float Width);
    

    enum GemstoneType
    {
        Emerald,Amber,Sapphire,Diamond,Bitstone
    }
    
    enum MaterialType
    {
        Wood,Bronze,Iron,Steel,Binarium
    }
    
    
}