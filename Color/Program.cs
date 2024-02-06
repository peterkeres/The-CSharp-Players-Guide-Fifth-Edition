using System.Xml;

namespace Color // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Color color1 = new Color(20, 20, 20);
            Color color2 = Color.Green();

            Console.WriteLine($"Color 1 is: (R {color1.R}, G {color1.G}, B {color1.B})");
            Console.WriteLine($"Color 2 is: (R {color2.R}, G {color2.G}, B {color2.B})");
        }
    }


    public class Color
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }


        public Color(int r, int g, int b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }


        public static Color White()
        {
            return new Color(255, 255, 255);
        }

        public static Color Black()
        {
            return new Color(0, 0, 0);
        }

        public static Color Red()
        {
            return new Color(0, 0, 0);
        }

        public static Color Orange()
        {
            return new Color(255, 165, 0);
        }

        public static Color Yellow()
        {
            return new Color(255, 255, 0);
        }

        public static Color Green()
        {
            return new Color(0, 128, 0);
        }

        public static Color Blue()
        {
            return new Color(0, 0, 255);
        }

        public static Color Purple()
        {
            return new Color(128, 0, 128);
        }
        
        
        
    }
    
    
    
    
    
    
}