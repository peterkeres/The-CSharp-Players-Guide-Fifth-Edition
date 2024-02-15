namespace Labeling_Inventory;

public class Sword : InventoryItem
{
    public Sword() : base(5.0f, 3.0f)
    {
    }
    
    public override string ToString()
    {
        return "Sword";
    }
}