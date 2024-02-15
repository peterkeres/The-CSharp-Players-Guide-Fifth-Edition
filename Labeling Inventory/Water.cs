namespace Labeling_Inventory;

public class Water : InventoryItem
{
    public Water() : base(2.0f, 3.0f)
    {
    }
    
    public override string ToString()
    {
        return "Water";
    }
}