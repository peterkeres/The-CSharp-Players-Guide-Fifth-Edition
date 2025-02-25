namespace Navigating_Operand_City;

class Program
{
    
    static void Main(string[] args)
    {

        var ex1 = new BlockCoordinate(1, 1);
        var move1 = new BlockOffset(3, 3);
        Console.Out.WriteLine($"Ex1: {ex1}");
        Console.Out.WriteLine($"After offSet: {ex1+move1}");
        
         var ex2 = new BlockCoordinate(1, 1);
         var move2 = Direction.North;
         Console.Out.WriteLine($"Ex2: {ex2}");
         Console.Out.WriteLine($"After move north: {ex2+move2}");







    }



    public record BlockCoordinate(int Row, int Column)
    {
        public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b) => new BlockCoordinate((a.Row + b.RowOffset),(a.Column + b.ColumnOffset));

        public static BlockCoordinate operator +(BlockCoordinate a, Direction b)
        {
            return a + (b switch
            {
                Direction.North => new BlockOffset(-1, 0),
                Direction.South => new BlockOffset(+1, 0),
                Direction.West  => new BlockOffset(0, -1),
                Direction.East  => new BlockOffset(0, +1),
            });
        }
    }
    public record BlockOffset(int RowOffset, int ColumnOffset);
    public enum Direction {North, East, South, West }




}