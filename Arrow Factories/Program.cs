Arrow arrow = GetArrow();
Console.WriteLine($"That arrow costs {arrow.Cost} gold.");



Arrow GetArrow()
{
    Console.WriteLine("What kinda of arrow do you want:");
    Console.WriteLine("1 - Elite Arrow");
    Console.WriteLine("2 - Beginner Arrow");
    Console.WriteLine("3 - Marksman Arrow");
    Console.WriteLine("4 - Custom Arrow");

    int userChoice = Convert.ToInt32(Console.ReadLine());
    Arrow userArrow;
    
    switch (userChoice)
    {
        case 1:
            userArrow = Arrow.CreateEliteArrow();
            break;
        case 2:
            userArrow = Arrow.CreateBeginnerArrow();
            break;
        case 3:
            userArrow = Arrow.CreateMarksmanArrow();
            break;
        default:
            userArrow = new Arrow(GetArrowheadType(), GetFletchingType(), GetLength());
            break;
    }

    return userArrow;
    
}




Arrowhead GetArrowheadType()
{
    Console.Write("Arrowhead type (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletchingType()
{
    Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feather" => Fletching.TurkeyFeathers,
        "goose feather" => Fletching.GooseFeathers
    };
}

float GetLength()
{
    float length = 0;

    while (length < 60 || length > 100)
    {
        Console.Write("Arrow length (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

public class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public float Length { get; }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }

    public float Cost
    {
        get
        {
            float arrowheadCost = Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5
            };

            float fletchingCost = Fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            float shaftCost = 0.05f * Length;

            return arrowheadCost + fletchingCost + shaftCost;
        }
    }

    public static Arrow CreateEliteArrow()
    {
        return new Arrow(Arrowhead.Steel, Fletching.Plastic, 95.0f);
    }

    public static Arrow CreateBeginnerArrow()
    {
        return new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75.0f);
    }

    public static Arrow CreateMarksmanArrow()
    {
        return new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65.0f);
    }
    
    
    
    
}

public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
