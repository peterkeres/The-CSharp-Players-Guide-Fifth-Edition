namespace Locked_Door // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("enter a pass code");
            int code = Convert.ToInt32(Console.ReadLine());
            Door door = new Door(code);
            string userCommand;


            while (true)
            {
                Console.WriteLine($"Door status is {door.DoorStatus} and {door.LockStatus}");

                Console.Write("command: ");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "open":
                        door.Open();
                        break;
                    case "close":
                        door.Close();
                        break;
                    case "lock":
                        door.Lock();
                        break;
                    case "unlock":
                        Console.WriteLine("enter pass code");
                        int userPass; userPass = Convert.ToInt32(Console.ReadLine());
                        door.Unlock(userPass);
                        break;
                    case "update":
                        Console.WriteLine("enter a current pass code");
                        int currentPass = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter a new pass code");
                        int newPass = Convert.ToInt32(Console.ReadLine());
                        door.UpdatePasscode(currentPass, newPass);
                        break;
                }
                

            }






        }
    }









    public class Door
    {
        public LockStatus LockStatus { get; private set; } = LockStatus.Locked;
        public DoorStatus DoorStatus { get; private set; } = DoorStatus.Closed;

        private int Passcode { get; set; }


        public Door(int passcode)
        {
            this.Passcode = passcode;
        }




        public void UpdatePasscode(int currentPass, int newPass)
        {
            if (currentPass == Passcode)
            {
                Passcode = newPass;
            }
        }
        

        public void Lock()
        {
            if (LockStatus == LockStatus.Unlocked && DoorStatus == DoorStatus.Closed)
            {
                LockStatus = LockStatus.Locked;
            }
        }

        public void Unlock(int passcode)
        {
            if (Passcode == passcode && LockStatus == LockStatus.Locked && DoorStatus == DoorStatus.Closed)
            {
                LockStatus = LockStatus.Unlocked;
            }
        }

        public void Open()
        {
            if (LockStatus == LockStatus.Unlocked && DoorStatus == DoorStatus.Closed)
            {
                DoorStatus = DoorStatus.Open;
            }
        }

        public void Close()
        {
            if (LockStatus == LockStatus.Unlocked && DoorStatus == DoorStatus.Open)
            {
                DoorStatus = DoorStatus.Closed;
            }
            
        }


    }








    public enum LockStatus
    {
        Locked,Unlocked
    }

    public enum DoorStatus
    {
        Open,Closed
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
}