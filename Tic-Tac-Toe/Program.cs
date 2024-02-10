namespace Tic_Tac_Toe // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GameManager.RunGame();
            
            

        }
    }
    
    
    public static class GameManager
    {
        private static int roundCount = 0;
        private static Player player1 = new Player('X');
        private static Player player2 = new Player('O');

        public static void RunGame()
        {
            GameBoard.CleanBoard();
            Player currentPlayer;

            do
            {
                currentPlayer = (roundCount%2 == 0 ) ? player1 : player2;
                RunRound(currentPlayer);
            } while (!GameBoard.aWinner() && !GameBoard.isFull());

            if (GameBoard.aWinner())
            {
                Console.WriteLine($"game is over, {currentPlayer.PlayerSymbol} won");
                UI.ShowBoard(null);
            }

            if (GameBoard.isFull() && !GameBoard.aWinner())
            {
                Console.WriteLine("Game is a draw, board is full and no one won");
                UI.ShowBoard(null);
            }



        }
        

        private static void RunRound(Player currentPlayer)
        {
            roundCount++;
            UI.ShowBoard(currentPlayer);
            GameBoard.UpdateCell(currentPlayer.PlayerSymbol,currentPlayer.GetPlayerMove());
        }
    }



    public static class UI
    {


        public static void ShowBoard(Player? currentPlayer)
        {
            if (currentPlayer != null) Console.WriteLine($"Its {currentPlayer.PlayerSymbol}'s turn\n");

            Console.WriteLine($" {GameBoard.Board[0]} | {GameBoard.Board[1]} | {GameBoard.Board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GameBoard.Board[3]} | {GameBoard.Board[4]} | {GameBoard.Board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GameBoard.Board[6]} | {GameBoard.Board[7]} | {GameBoard.Board[8]} ");
            
        }
        
        
        
    }


    public static class GameBoard
    {
        public static char[] Board { get; set; } = new Char[9];

        public static void CleanBoard()
        {
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = ' ';
            }
        }

        public static void UpdateCell(char playerSymbol, int playerCell)
        {
            Board[playerCell] = playerSymbol;
        }

        public static bool aWinner()
        {

            bool winner = false;

            if (Board[0] != ' ' && Board[0] == Board[1] && Board[1] == Board[2]) winner = true;
            if (Board[0] != ' ' && Board[0] == Board[3] && Board[3] == Board[6]) winner = true;
            if (Board[0] != ' ' && Board[0] == Board[4] && Board[4] == Board[8]) winner = true;
            
            if (Board[1] != ' ' && Board[1] == Board[4] && Board[4] == Board[7]) winner = true;
            
            if (Board[2] != ' ' && Board[2] == Board[5] && Board[5] == Board[8]) winner = true;
            if (Board[2] != ' ' && Board[2] == Board[4] && Board[4] == Board[6]) winner = true;
            
            if (Board[3] != ' ' && Board[3] == Board[4] && Board[4] == Board[5]) winner = true;
            
            if (Board[6] != ' ' && Board[6] == Board[7] && Board[7] == Board[8]) winner = true;
            
            return winner;
        }

        public static bool isLegalMove(int cell)
        {
            return Board[cell] == ' ';
        }

        public static bool isFull()
        {
            bool isFull = true;
            
            foreach (var cell in Board)
            {
                if (cell == ' ') isFull = false;
            }

            return isFull;
        }

    }

    

    public class Player
    {
        public char PlayerSymbol { get; private set; }


        public Player(char playerSymbol)
        {
            PlayerSymbol = playerSymbol;
        }

        public int GetPlayerMove()
        {
            bool legalMove;
            int userMove;
            
            do
            {
                Console.WriteLine("What Square do you want to play in?");
                userMove = Convert.ToInt32(Console.ReadLine()) - 1;
                userMove = Math.Clamp(userMove, 0, 8);
                legalMove = GameBoard.isLegalMove(userMove);
                if (!legalMove) Console.WriteLine("not legal move, try again");
            } while (!legalMove);
            
            
            return userMove;
        }
        
    }

}