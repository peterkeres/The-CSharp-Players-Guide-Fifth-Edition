namespace Fountain_of_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager.Run();
        }
    }
    
    
    
    static class Ui
    {
        private static char displayCaracterSeperator = '-';
        private static int displaySeperatorLength = 70;

        private static ConsoleColor narrativeTextColor = ConsoleColor.Magenta;
        private static ConsoleColor descriptiveTextColor = ConsoleColor.White;
        private static ConsoleColor userTextColor = ConsoleColor.Cyan;
        private static ConsoleColor entranceTextColor = ConsoleColor.Yellow;
        private static ConsoleColor fountainTextColor = ConsoleColor.Blue;
        private static ConsoleColor eventTextColor = ConsoleColor.DarkRed;

        public static void DisplayRound(Room currentRoom, RoomPosition roomPosition)
        {
            PlayerCommand playerCommand;
            bool validCommand;
            
            Console.WriteLine(new string(displayCaracterSeperator,displaySeperatorLength));
            DisplayRoomInfo(currentRoom, roomPosition);
            do
            {
                playerCommand = GetPlayerCommand();
                validCommand = GameManager.CanExecuteCommand(playerCommand);
                if(!validCommand) Console.Write("UNABLE TO TAKE ACTION:");
            } while (!validCommand);

            GameManager.ExcuateCommand(playerCommand);
        }

        public static CavernSize GetCavernSize()
        {
            string userChoice;
            
            do
            {
                Console.Write("please select the size of the cavern (small, medium, or large): ");
                userChoice = Console.ReadLine();

                if (userChoice.ToLower() == CavernSize.Small.ToString().ToLower())
                {
                    return CavernSize.Small;
                }
                if (userChoice.ToLower() == CavernSize.Medium.ToString().ToLower())
                {
                    return CavernSize.Medium;
                }
                if (userChoice.ToLower() == CavernSize.Large.ToString().ToLower())
                {
                    return CavernSize.Large;
                }
                
                
                Console.WriteLine("not a valid option, try again.");
            } while (true);
            
        }


        public static void DisplayGameStart()
        {
            Console.ForegroundColor = narrativeTextColor;
            Console.WriteLine("Welcome to the fountain of objects!\n" +
                              "Goal is to find the Fountain of Objects, activate it, then return to the entrance room\n" +
                              "Good luck player!");
            Console.WriteLine("\n\n");
            Console.ForegroundColor = descriptiveTextColor;

        }

        public static void DisplayGameWon()
        {
            Console.ForegroundColor = narrativeTextColor;
            Console.WriteLine("\n\n");
            Console.WriteLine("Wow you have done it, you went in and activated the fountain of objects\n" +
                              "all can now live in peace i guess\n" +
                              "time to log off and eat some dinner!");
            Console.ForegroundColor = descriptiveTextColor;
            Environment.Exit(0);
            
        }

        public static void CommandResultMessage(string message)
        {
            Console.ForegroundColor = eventTextColor;
            Console.WriteLine(message);
            Console.ForegroundColor = descriptiveTextColor;
        }
        
        private static void DisplayRoomInfo(Room room, RoomPosition roomPosition)
        {
            Console.WriteLine($"You are in the room at {roomPosition}");
            if (room.GetType() == typeof(FountainRoom)) Console.ForegroundColor = fountainTextColor;
            if (room.GetType() == typeof(StartRoom)) Console.ForegroundColor = entranceTextColor;
            
            if (room.RoomDescription is not null) Console.WriteLine(room.RoomDescription);
            Console.ForegroundColor = descriptiveTextColor;


        }

        private static PlayerCommand GetPlayerCommand()
        {
            PlayerCommand? playerCommand;
            
            do
            {
                Console.Write("What do you want to do? ");
                Console.ForegroundColor = userTextColor;
                playerCommand = convertPlayerCommand(Console.ReadLine());
                Console.ForegroundColor = descriptiveTextColor;
                if(playerCommand is null) Console.WriteLine("ERROR: not valid command, try again");
            } while (playerCommand is null);
            

            return playerCommand;
        }

        private static PlayerCommand? convertPlayerCommand(string userCommand)
        {
            PlayerCommand? playerCommand = null;
            userCommand = userCommand.ToLower();

            string?[] userSplit = userCommand.Split(" ");


            if (userSplit.Length == 2)
            {
                if (userSplit[0] == PlayerAction.Move.ToString().ToLower())
                {
                    switch (userSplit[1])
                    {  
                       case "north":
                           playerCommand = new PlayerCommand(PlayerAction.Move, PlayerActionArguments.North);
                           break;
                       case "south":
                           playerCommand = new PlayerCommand(PlayerAction.Move, PlayerActionArguments.South);
                           break;
                       case "east":
                           playerCommand = new PlayerCommand(PlayerAction.Move, PlayerActionArguments.East);
                           break;
                       case "west":
                           playerCommand = new PlayerCommand(PlayerAction.Move, PlayerActionArguments.West);
                           break;
                    }
                }

                if (userSplit[0] == PlayerAction.Enable.ToString().ToLower())
                {
                    switch (userSplit[1])
                    {
                        case "fountain":
                            playerCommand = new PlayerCommand(PlayerAction.Enable, PlayerActionArguments.Fountain);
                            break;
                    }
                }
                
            }
            
            
            
            return playerCommand;
        }
        
        
    
    }

    // holds display about room
    class Room
    {
        public string? RoomDescription { get; protected set; }

        public Room()
        {
            RoomDescription = null;
        }
        
        public Room(string roomDescription)
        {
            RoomDescription = roomDescription;
        }

        public virtual bool Enable(PlayerCommand command)
        {
            Ui.CommandResultMessage("Nothing happens.");
            return false;
        }
        
    }

    class StartRoom : Room
    {
        public StartRoom()
        {
            RoomDescription = "You see light coming from the cavern entrance.";
        }
    }

    class FountainRoom : Room
    {
        
        public bool IsFountainActive { get; private set; }
        public FountainRoom()
        {
            RoomDescription = "You hear water dripping in this room. The fountain of objects is here!";
            IsFountainActive = false;
        }

        public override bool Enable(PlayerCommand command)
        {
            bool actionWorked = false;

            if (command.Action == PlayerAction.Enable && command.PlayerActionArguments == PlayerActionArguments.Fountain)
            {
                RoomDescription = "The water is flowing, the Fountain of Objects is active. It has been reactivated!";
                IsFountainActive = true;
                actionWorked = true;
                Ui.CommandResultMessage("The water starts to flow, the fountain is working again!");
            }


            return actionWorked;
        }
    }

    // holds links to all rooms
    // confimrs is moves are valid
    // confimrs win condition
    class Cavern
    {
        private Room[,] rooms;
        public Room CurrentRoom { get; private set; }
        public RoomPosition CurrentRoomPosition { get; private set; }
        public bool FountainActive { get; set; }
        private int maxRows;
        private int maxColumns;
        

        public Cavern(CavernSize cavernSize)
        {
            switch (cavernSize)
            {
                case CavernSize.Small:
                    MakeSmallCavern();
                    break;
                case CavernSize.Medium:
                    MakeMediumCavern();
                    break;
                case CavernSize.Large:
                    MakeLargeCavern();
                    break;
            }

        }


        private void MakeBlankCavern(int rows, int columns)
        {
            rooms = new Room[rows, columns];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    rooms[i, j] = new Room();
                }
            }

            maxColumns = columns;
            maxRows = rows;
        }
        
        
        private void MakeSmallCavern()
        {
            MakeBlankCavern(4,4);
            rooms[0, 0] = new StartRoom();
            rooms[0, 2] = new FountainRoom();
            
            CurrentRoom = rooms[0, 0];
            CurrentRoomPosition = new RoomPosition(0, 0);
        }

        private void MakeMediumCavern()
        {
            MakeBlankCavern(6,6);
            rooms[0, 0] = new StartRoom();
            rooms[0, 4] = new FountainRoom();
            
            CurrentRoom = rooms[0, 0];
            CurrentRoomPosition = new RoomPosition(0, 0);
        }

        private void MakeLargeCavern()
        {
            MakeBlankCavern(8,8);
            rooms[0, 0] = new StartRoom();
            rooms[0, 6] = new FountainRoom();
            
            CurrentRoom = rooms[0, 0];
            CurrentRoomPosition = new RoomPosition(0, 0);
        }

        public bool CanMakeMove(PlayerCommand command)
        {
            bool canMove = false;

            if (command.Action == PlayerAction.Move && command.PlayerActionArguments == PlayerActionArguments.North)
            {
                if (CurrentRoomPosition.Row - 1 >= 0) canMove = true;
            }
            else if (command.Action == PlayerAction.Move && command.PlayerActionArguments == PlayerActionArguments.South)
            {
                if (CurrentRoomPosition.Row + 1 < maxRows) canMove = true;
            }
            else if (command.Action == PlayerAction.Move && command.PlayerActionArguments == PlayerActionArguments.East)
            {
                if (CurrentRoomPosition.Column + 1 < maxColumns) canMove = true;
            }
            else if (command.Action == PlayerAction.Move && command.PlayerActionArguments == PlayerActionArguments.West)
            {
                if (CurrentRoomPosition.Column - 1 >= 0) canMove = true;
            }

            return canMove;
        }

        public void movePlayer(PlayerCommand command)
        {
            if (command.PlayerActionArguments == PlayerActionArguments.North)
            {
                CurrentRoom = rooms[CurrentRoomPosition.Column, CurrentRoomPosition.Row-1];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Column, CurrentRoomPosition.Row-1);
            }
            else if (command.PlayerActionArguments == PlayerActionArguments.South)
            {
                CurrentRoom = rooms[CurrentRoomPosition.Column, CurrentRoomPosition.Row +1];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Column, CurrentRoomPosition.Row +1);
            }
            else if (command.PlayerActionArguments == PlayerActionArguments.East)
            {
                CurrentRoom = rooms[CurrentRoomPosition.Column+1, CurrentRoomPosition.Row ];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Column+1, CurrentRoomPosition.Row );
            }
            else if (command.PlayerActionArguments == PlayerActionArguments.West)
            {
                CurrentRoom = rooms[CurrentRoomPosition.Column-1, CurrentRoomPosition.Row];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Column-1, CurrentRoomPosition.Row);
            }
        }
        
        
    }

    // takes commands and attempts to exute them
    // tells ui when to display and ask for input
    // tells UI when game is over
    static class GameManager
    {
        private static Cavern cavern;
        private static bool fountainActive;
        private static bool gameOverEvent;
        private static bool playerWonEvent;

        public static void Run()
        {
            cavern = new Cavern(Ui.GetCavernSize());
            Ui.DisplayGameStart();
            
            do
            {
                RunRound();
            } while (!gameOverEvent);

            if (playerWonEvent)
            {
                Ui.DisplayGameWon();
            }
        }

        public static void RunRound()
        {
            Ui.DisplayRound(cavern.CurrentRoom, cavern.CurrentRoomPosition);
            CheckPlayerWon();
        }

        private static void CheckPlayerWon()
        {
            if (cavern.CurrentRoom.GetType() == typeof(FountainRoom))
            {
                var temp = (FountainRoom)cavern.CurrentRoom;
                fountainActive = temp.IsFountainActive;
            }
            
            if (fountainActive && cavern.CurrentRoom.GetType() == typeof(StartRoom))
            {
                playerWonEvent = true;
            }
            
            if (playerWonEvent)
            {
                gameOverEvent = true;
            }
        }
        
        public static bool CanExecuteCommand(PlayerCommand command)
        {
            bool canDoCommand = false;
            
            if (command.Action == PlayerAction.Move)
            {
                canDoCommand = cavern.CanMakeMove(command);
            }

            if (command.Action == PlayerAction.Enable)
            {
                canDoCommand = true;
            }

            return canDoCommand;
        }

        public static void ExcuateCommand(PlayerCommand command)
        {
            if (command.Action == PlayerAction.Move)
            {
                cavern.movePlayer(command);
            }

            if (command.Action == PlayerAction.Enable)
            {
                cavern.CurrentRoom.Enable(command);
            }
        }
        
    }
    
    
    enum PlayerAction
    {
        Move,Enable
    }

    enum PlayerActionArguments
    {
        Fountain,North,South,East,West
    }

    enum CavernSize
    {
        Small,Medium,Large
    }

    record PlayerCommand(PlayerAction Action, PlayerActionArguments PlayerActionArguments);
    record RoomPosition(int Column, int Row);








}