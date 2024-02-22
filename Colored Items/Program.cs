namespace Colored_Items // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ColoredItem<Sword> sword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
            ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
            ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);
            
            sword.Display();
            bow.Display();
            axe.Display();

        }
    }

    class ColoredItem<T>
    {
        public T Item { get;}
        public ConsoleColor ConsoleColor { get; }


        public ColoredItem(T item,ConsoleColor consoleColor)
        {
            ConsoleColor = consoleColor;
            Item = item;
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor;
            Console.WriteLine(Item);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        
    }
    
    

    class Sword
    {
        
    }

    class Bow
    {
        
    }

    class Axe
    {
        
    }
    
    
    
    
    
    
    
    
}