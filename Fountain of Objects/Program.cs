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

        public static void DisplayRound(Room currentRoom, RoomPosition roomPosition,int maxNumArrows ,int numOfArrows)
        {
            Console.WriteLine(new string(displayCaracterSeperator,displaySeperatorLength));
            Console.WriteLine($"Current number of arrows left:  {maxNumArrows - numOfArrows} ");
            DisplayRoomInfo(currentRoom, roomPosition);
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
            Console.WriteLine("You enter the Cavern of objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.\n" +
                              "Light is visible only in the entrance and no other light is seen anywhere in the caverns.\n" +
                              "you must navigate the caverns with your other senses.\n" +
                              "find the fountain of objects, activate it, and return to the entrance.\n" +
                              "look out for pits. you will feel a breeze if a pit is in an adjance rom. if you enter a room with a pit you will die.\n" +
                              "maelstroms are voilent froces of sentient wind. entring a room with one could transport you to any other location in the caverns. you will be able to hear their growling and goraning in nearbvys rooms.\n" +
                              "amaroks roam the caverns. encountering on eis certain death, but you can semll their rotten stench in neary rooms.\n" +
                              "you carry with you a bow and a quiver of arrows. you can use them to shoot monsters in the caverns but be warned. you have a limited supply.\n" +
                              "Type in 'help' for a list of commands to enter.\n\n");
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

        public static void DisplayGameLost()
        {
            Console.ForegroundColor = narrativeTextColor;
            Console.WriteLine("\n\n");
            Console.WriteLine("Its sad to have come this far just to lose\n" +
                              "The fountain will remained closed until another hero shows up.\n" +
                              "Cant win them all i guess");
            Console.ForegroundColor = descriptiveTextColor;
            Environment.Exit(0);
        }

        public static void EventMessage(string message)
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

        public static void DisplayHelp()
        {
            Console.WriteLine("\nThe player can use the following commands.\n" +
                              "help - displays this help menu, no arguemnts.\n" +
                              "move - moves the player one space, has one argument direction.\n" +
                              "\t {direction} what direction you have to move. 4 options: north, south, east, west.\n" +
                              "shoot - shoots an arrow one space in a direction, has one argument direction.\n" +
                              "\t {direction} what direction you want to shoot in. 4 options: north, south, east, west.\n" +
                              "enable - activates an object in the room. has one argument object.\n" +
                              "\t {object} what object you want to interact with in the room. 1 option: fountain.\n");
        }

        public static PlayerCommand GetPlayerCommand()
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


            if (userSplit.Length == 1 && userSplit[0] == PlayerAction.Help.ToString().ToLower())
            {
                playerCommand = new PlayerCommand(PlayerAction.Help, null);
            }

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
                
                if (userSplit[0] == PlayerAction.Shoot.ToString().ToLower())
                {
                    switch (userSplit[1])
                    {  
                        case "north":
                            playerCommand = new PlayerCommand(PlayerAction.Shoot, PlayerActionArguments.North);
                            break;
                        case "south":
                            playerCommand = new PlayerCommand(PlayerAction.Shoot, PlayerActionArguments.South);
                            break;
                        case "east":
                            playerCommand = new PlayerCommand(PlayerAction.Shoot, PlayerActionArguments.East);
                            break;
                        case "west":
                            playerCommand = new PlayerCommand(PlayerAction.Shoot, PlayerActionArguments.West);
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
        public string? RoomDescription { get; protected set; } = null;
        public string? RoomAdjacentSense { get; protected set; } = null;
        public bool BeenShot { get; protected set; } = false;
        
        public virtual bool Enable(PlayerCommand command)
        {
            Ui.EventMessage("Nothing happens.");
            return false;
        }

        public virtual void PlayerEnterEvent()
        {
            
        }

        public virtual void ShootAtEvent()
        {
            
        }
        
    }


    class MaelstromsRoom : Room
    {
        public MaelstromsRoom()
        {
            RoomDescription = "You see a sentient, malevolent wind figure standing infront of you. It grows in size and anger.";
            RoomAdjacentSense = "You hear the growling and goraning of a maelstrom nearby.";
        }

        public override void PlayerEnterEvent()
        {
            if (!BeenShot)
            {
                GameManager.RepositionMaelstrom(1,-2);
                Ui.EventMessage("Player is sent flying across the cavern to a new location");
                GameManager.RepositionPlayer(-1,2);
            }

        }

        public override void ShootAtEvent()
        {
            RoomAdjacentSense = null;
            RoomDescription = "You see before you a dead Maelstrom";
            BeenShot = true;
        }
    }
    
    class AmaroksRoom : Room    
    {

        public AmaroksRoom()
        {
            RoomDescription = "You see a large, giant, wolf like creature infornt of you.";
            RoomAdjacentSense = "You can smell the rotten stench of an amarok in a nearby room.";
        }

        public override void PlayerEnterEvent()
        {
            if (!BeenShot)
            {
                Ui.EventMessage("The Large Amaroks attacks!");
                GameManager.PlayerDeath();
            }
        }

        public override void ShootAtEvent()
        {
            RoomAdjacentSense = null;
            RoomDescription = "You see before you a dead Wolf";
            BeenShot = true;
        }
    }
    
    
    class PitRoom : Room
    {

        public PitRoom()
        {
            RoomDescription = "something seems off about this room, the floor feels weak.";
            RoomAdjacentSense = "You feel a draft. there is a pit in a nearby room.";
        }

        public override void PlayerEnterEvent()
        {
            Ui.EventMessage("The floor breaks free and you fall to your death.");
            GameManager.PlayerDeath();
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
                Ui.EventMessage("The water starts to flow, the fountain is working again!");
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
            rooms[2, 0] = new FountainRoom();
            rooms[0, 2] = new PitRoom();
            rooms[2, 2] = new MaelstromsRoom();
            
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

        public void NearByRoomSense()
        {
            if (CurrentRoomPosition.Row - 1 >= 0 && CurrentRoomPosition.Column -1 >= 0)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row - 1, CurrentRoomPosition.Column - 1].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
            if (CurrentRoomPosition.Row - 1 >= 0 && CurrentRoomPosition.Column >= 0)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row - 1, CurrentRoomPosition.Column].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
            if (CurrentRoomPosition.Row - 1 >= 0 && CurrentRoomPosition.Column +1 < maxColumns)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row - 1, CurrentRoomPosition.Column + 1].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
            
            if (CurrentRoomPosition.Row >= 0 && CurrentRoomPosition.Column +1 < maxColumns)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row, CurrentRoomPosition.Column + 1].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
            if (CurrentRoomPosition.Row + 1 < maxRows && CurrentRoomPosition.Column +1 < maxColumns)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row + 1, CurrentRoomPosition.Column + 1].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
            
            if (CurrentRoomPosition.Row + 1 < maxRows && CurrentRoomPosition.Column >= 0)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row + 1, CurrentRoomPosition.Column].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
            if (CurrentRoomPosition.Row + 1 < maxRows && CurrentRoomPosition.Column -1 >= 0)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row + 1, CurrentRoomPosition.Column - 1].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
            if (CurrentRoomPosition.Row >= 0 && CurrentRoomPosition.Column -1 >= 0)
            {
                var roomAdjacentSense = rooms[CurrentRoomPosition.Row, CurrentRoomPosition.Column - 1].RoomAdjacentSense;
                if (roomAdjacentSense is not null) Ui.EventMessage(roomAdjacentSense);
            }
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
                CurrentRoom = rooms[CurrentRoomPosition.Row-1, CurrentRoomPosition.Column];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Row-1, CurrentRoomPosition.Column);
            }
            else if (command.PlayerActionArguments == PlayerActionArguments.South)
            {
                CurrentRoom = rooms[CurrentRoomPosition.Row +1,CurrentRoomPosition.Column];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Row +1,CurrentRoomPosition.Column);
            }
            else if (command.PlayerActionArguments == PlayerActionArguments.East)
            {
                CurrentRoom = rooms[CurrentRoomPosition.Row, CurrentRoomPosition.Column+1];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Row, CurrentRoomPosition.Column+1);
            }
            else if (command.PlayerActionArguments == PlayerActionArguments.West)
            {
                CurrentRoom = rooms[CurrentRoomPosition.Row,CurrentRoomPosition.Column-1];
                CurrentRoomPosition = new RoomPosition(CurrentRoomPosition.Row,CurrentRoomPosition.Column-1);
            }
        }


        public void RepositionPlayer(int rowsToMove, int columnsToMove)
        {
            int rowMovingTo = Math.Clamp(CurrentRoomPosition.Row + rowsToMove, 0, maxRows -1);
            int columnMovingTo = Math.Clamp(CurrentRoomPosition.Column + columnsToMove, 0, maxColumns -1);

            CurrentRoom = rooms[rowMovingTo, columnMovingTo];
            CurrentRoomPosition = new RoomPosition(rowMovingTo, columnMovingTo);

        }

        public void RepositionMaelstrom(int rowsToMove, int columnsToMove)
        {
            int rowMovingTo = Math.Clamp(CurrentRoomPosition.Row + rowsToMove, 0, maxRows -1);
            int columnMovingTo = Math.Clamp(CurrentRoomPosition.Column + columnsToMove, 0, maxColumns -1);

            if (rooms[rowMovingTo, columnMovingTo].GetType() != typeof(Room)) rowMovingTo += 1;
            if (rooms[rowMovingTo, columnMovingTo].GetType() != typeof(Room)) columnMovingTo += 1;

            rooms[CurrentRoomPosition.Row, CurrentRoomPosition.Column] = new Room();
            rooms[rowMovingTo, columnMovingTo] = new MaelstromsRoom();

        }

        public void FireArrow(PlayerActionArguments? direction)
        {
            int row = CurrentRoomPosition.Row, column = CurrentRoomPosition.Column;

            if (direction == PlayerActionArguments.East) column += 1;
            else if (direction == PlayerActionArguments.West) column -= 1;
            else if (direction == PlayerActionArguments.North) row -= 1;
            else if (direction == PlayerActionArguments.South) row += 1;


            RoomPosition roomToShoot = new RoomPosition(Math.Clamp(row, 0, maxRows - 1), Math.Clamp(column, 0, maxColumns -1));
            
            rooms[roomToShoot.Row,roomToShoot.Column].ShootAtEvent();

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
        private static int maxNumArrows, shotNumArrows;

        public static void Run()
        {
            cavern = new Cavern(Ui.GetCavernSize());
            Ui.DisplayGameStart();
            maxNumArrows = 2;
            
            do
            {
                RunRound();
            } while (!gameOverEvent);

            if (playerWonEvent)
            {
                Ui.DisplayGameWon();
            }
            else
            {
                Ui.DisplayGameLost();   
            }
        }

        public static void PlayerDeath()
        {
            playerWonEvent = false;
            gameOverEvent = true;
        }

        public static void RunRound()
        {
            Ui.DisplayRound(cavern.CurrentRoom, cavern.CurrentRoomPosition,maxNumArrows, shotNumArrows);
            cavern.NearByRoomSense();
            PlayerCommand playerCommand = Ui.GetPlayerCommand();
            
            if (CanExecuteCommand(playerCommand))
            {
                ExcuateCommand(playerCommand);
            }
            else
            {
                Ui.EventMessage("UNABLE TO TKAE ACTION");
            }
            
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

            if (command.Action == PlayerAction.Enable || command.Action == PlayerAction.Shoot || command.Action == PlayerAction.Help)
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
                cavern.CurrentRoom.PlayerEnterEvent();
            }

            if (command.Action == PlayerAction.Enable)
            {
                cavern.CurrentRoom.Enable(command);
            }

            if (command.Action == PlayerAction.Shoot)
            {
                if (shotNumArrows < maxNumArrows)
                {
                    Ui.EventMessage("ARROW FIRED");
                    shotNumArrows++;
                    cavern.FireArrow(command.PlayerActionArguments);
                }
                else
                {
                    Ui.EventMessage("OUT OF ARROWS");
                }
               
            }

            if (command.Action == PlayerAction.Help)
            {
                Ui.DisplayHelp();
            }
        }

        public static void RepositionPlayer(int rowsToMove, int columnsToMove)
        {
            cavern.RepositionPlayer(rowsToMove,columnsToMove);
        }

        public static void RepositionMaelstrom(int rowsToMove, int columnsToMove)
        {
            cavern.RepositionMaelstrom(rowsToMove,columnsToMove);
        }
        
    }
    
    
    enum PlayerAction
    {
        Move,Enable,Shoot,Help
    }

    enum PlayerActionArguments
    {
        Fountain,North,South,East,West
    }

    enum CavernSize
    {
        Small,Medium,Large
    }

    record PlayerCommand(PlayerAction Action, PlayerActionArguments? PlayerActionArguments);
    record RoomPosition(int Row, int Column);








}