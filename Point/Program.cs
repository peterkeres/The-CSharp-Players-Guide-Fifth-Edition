namespace Point // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(2, 3);
            Point point2 = new Point(-4, 0);

            Console.WriteLine($"point 1's coordinates are ({point1.X},{point1.Y})");
            Console.WriteLine($"point 2's coordinates are ({point2.X},{point2.Y})");

        }
    }




    class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }


        public Point() : this(0, 0)
        {
            
        }
        
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        

    }
    
    
    
    
    
    
    
}