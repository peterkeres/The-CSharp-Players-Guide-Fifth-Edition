namespace Simulas_Test
{
    internal class Program
    {
        
        
        
        static void Main(string[] args)
        {
            ChestStates currentState = ChestStates.Locked;
            string userAction;


            while (true)
            {
                Console.Out.Write($"The chest is {currentState.ToString()}. What do you want to do? ");
                userAction = Console.ReadLine();

                if (userAction == "unlock")
                {
                    currentState =  NextChestState(currentState, ChestActions.Unlock);
                }
                else if (userAction == "lock")
                {
                    currentState = NextChestState(currentState, ChestActions.Lock);
                }
                else if (userAction == "open")
                {
                    currentState = NextChestState(currentState, ChestActions.Open);
                }
                else if (userAction == "close")
                {
                    currentState = NextChestState(currentState, ChestActions.Close);
                }
                else
                {
                    Console.Out.WriteLine("Not able to process that command, you have 4 options.\n\tlock\n\tunlock\n\topen\n\tclose");
                }
            }


        }
        
        
        


        static ChestStates NextChestState(ChestStates currentState, ChestActions currentCommand)
        {
            ChestStates nextState;
            
            switch (currentState, currentCommand)
            {
                case (ChestStates.Locked, ChestActions.Unlock):
                    nextState = ChestStates.Unlocked;
                    break;
                case (ChestStates.Unlocked, ChestActions.Open):
                    nextState = ChestStates.Open;
                    break;
                case (ChestStates.Open, ChestActions.Close):
                    nextState = ChestStates.Unlocked;
                    break;
                case (ChestStates.Unlocked, ChestActions.Lock):
                    nextState = ChestStates.Locked;
                    break;
                default:
                    Console.Out.WriteLine("ERROR: unknown state and command");
                    nextState = ChestStates.Locked;
                    break;
            }

            return nextState;

        }
        
        
    }

    enum ChestActions
    {
        Lock,
        Unlock,
        Open,
        Close
    }
    
    enum ChestStates
    {
        Locked,
        Unlocked,
        Open,
    }
}