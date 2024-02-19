namespace Room_Coordinates // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coordinate a = new Coordinate(3, 3);
            Coordinate b = new Coordinate(2, 3);
            Coordinate c = new Coordinate(2, 2);

            Console.WriteLine(a.isAdjacent(b)); // Should be True
            Console.WriteLine(b.isAdjacent(c)); // Should be True
            Console.WriteLine(a.isAdjacent(c)); // Should be False
        }
        
        
    }



    internal readonly struct Coordinate
    {
        int Row { get; }
        int Column { get; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }


        public bool isAdjacent(Coordinate other)
        {
            bool adjacent = false;

            int rowDifference = Row - other.Row;
            int columnDifference = Column - other.Column;

            if (Math.Abs(rowDifference) <= 1 && columnDifference == 0)
            {
                adjacent = true;
            }            
            if (Math.Abs(columnDifference) <= 1 && rowDifference == 0)
            {
                adjacent = true;
            }

            return adjacent;

        }
    }
    
    
    
}