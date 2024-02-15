namespace Labeling_Inventory;

public class Pack
{
    
    public int MaxItems { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }
    
    public int CurrentItemCount { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }

    private InventoryItem[] items;
    


    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;

        items = new InventoryItem[maxItems];
    }


    public bool Add(InventoryItem item)
    {
        bool added = false;
        
        if (item.Volume + CurrentVolume <= MaxVolume && item.Weight + CurrentWeight <= MaxWeight && CurrentItemCount 
            + 1 <= MaxItems )
        {
            items[CurrentItemCount] = item;
            CurrentItemCount++;
            CurrentVolume += item.Volume;
            CurrentWeight += item.Weight;
            added = true;
        }
        
        return added;
    }


    public override string ToString()
    {
        string inPack = "Pack holds: ";

        if (CurrentItemCount > 0)
        {
            foreach (var item in items)
            {
                if (item is not null) inPack += item.ToString() + " ";
            }
        }
        else
        {
            inPack += "nothing";
        }

        
        
        return inPack;
    }
}