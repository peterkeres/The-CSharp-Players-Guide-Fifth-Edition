namespace Labeling_Inventory;

public class Rope : InventoryItem
{
    public Rope() : base(1.0f, 1.5f)
    {
    }
    
    public override string ToString()
    {
        return "Rope";
    }
}