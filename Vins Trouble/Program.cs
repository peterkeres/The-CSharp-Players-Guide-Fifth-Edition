namespace Vin_Fletchers_Arrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Arrow Arrow = new Arrow();
            Console.WriteLine($"total cost of the arrow is {Arrow.GetCost()}");
            
        }

        
        
        public class Arrow
        {
            private ArrowheadType _arrowhead;
            private FletchingType _fletchingType;
            private float _length;


            public Arrow()
            {
                this._arrowhead = SetArrowhead();
                this._fletchingType = SetFletchingType();
                this._length = SetLength();
            }



            public ArrowheadType GetArrowhead() => _arrowhead;
            public FletchingType GetFletching() => _fletchingType;
            public float GetLength() => _length;
            
            
            
            public float GetCost()
            {

                float totalCost = 0.0f;

                switch (_arrowhead)
                {
                    case ArrowheadType.Wood:
                        totalCost += 3.0f;
                        break;
                    case ArrowheadType.Steel:
                        totalCost += 10.0f;
                        break;
                    case ArrowheadType.Obsidian:
                        totalCost += 5.0f;
                        break;
                }

                switch (_fletchingType)
                {
                    case FletchingType.Goose:
                        totalCost += 3.0f;
                        break;
                    case FletchingType.Plastic:
                        totalCost += 10.0f;
                        break;
                    case FletchingType.Turkey:
                        totalCost += 5.0f;
                        break;
                }

                totalCost += (_length * 0.05f);

                return totalCost;

            }


            private float SetLength()
            {
                float user = 0.0f;
                bool pass = false;

                do
                {
                    Console.WriteLine("enter length of shaft");
                    user = Convert.ToSingle(Console.ReadLine()); //skipping over try catch
                    if (user >= 60.0 || user <= 100.0 )
                    {
                        pass = true;
                    }
                    else
                    {
                        Console.WriteLine("please enter a range of 60.0 - 100.0");
                    }
                    
                } while (!pass);


                return user;

            }
            
            
            

            private FletchingType SetFletchingType()
            {
                FletchingType userPick = FletchingType.Goose;
                bool pass = false;

                do
                {
                    Console.WriteLine("pick fletching type:");
                    Console.WriteLine($"\t{FletchingType.Goose}\n\t{FletchingType.Plastic}\n\t{FletchingType.Turkey}");

                    string user = Console.ReadLine();

                    if (user == FletchingType.Goose.ToString() )
                    {
                        pass = true;
                        userPick = FletchingType.Goose;
                    }
                    else if (user == FletchingType.Plastic.ToString())
                    {
                        pass = true;
                        userPick = FletchingType.Plastic;
                    }
                    else if (user == FletchingType.Turkey.ToString())
                    {
                        pass = true;
                        userPick = FletchingType.Turkey;
                    }
                    else
                    {
                        Console.WriteLine("Not a option, pick again");
                    }
                    
                } while (!pass);

                return userPick;
            }
            
            
            
            
            private ArrowheadType SetArrowhead()
            {
                ArrowheadType userPick = ArrowheadType.Steel;
                bool pass = false;

                do
                {
                    Console.WriteLine("pick arrow head type:");
                    Console.WriteLine($"\t{ArrowheadType.Wood}\n\t{ArrowheadType.Steel}\n\t{ArrowheadType.Obsidian}");

                    string user = Console.ReadLine();

                    if (user == ArrowheadType.Wood.ToString() )
                    {
                        pass = true;
                        userPick = ArrowheadType.Wood;
                    }
                    else if (user == ArrowheadType.Steel.ToString())
                    {
                        pass = true;
                        userPick = ArrowheadType.Steel;
                    }
                    else if (user == ArrowheadType.Obsidian.ToString())
                    {
                        pass = true;
                        userPick = ArrowheadType.Obsidian;
                    }
                    else
                    {
                        Console.WriteLine("Not a option, pick again");
                    }
                    
                } while (!pass);

                return userPick;
            } 
            
            

        }


        public enum ArrowheadType{Steel,Wood,Obsidian}

        public enum FletchingType{Plastic,Turkey,Goose}
    }
}