namespace Labeling_Inventory;

public class Bow : InventoryItem
{
    public Bow() : base(1.0f, 4.0f)
    {
    }
    
    public override string ToString()
    {
        return "Bow";
    }
}