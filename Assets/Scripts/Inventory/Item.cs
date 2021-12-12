using UnityEngine;

public class Item 
{
    //Add item type here
    public enum ItemType
    {
        //TODO: Add more thing later (VS)
        //When adding more item, add them to the constructor
        Empty ,Screwdriver, Statue,
    }

    public readonly ItemType TypeOfItem;
    public readonly Sprite ItemSprite;
    public bool IsEquipped;
    public readonly bool IsRemovable;

    /// <summary>
    /// Constructor
    /// </summary>
    public Item(ItemType typeOfItem, bool isRemovable)
    {
        TypeOfItem = typeOfItem;
        switch (TypeOfItem)
        {
            case ItemType.Empty:
                ItemSprite = null;
                break;
            case ItemType.Screwdriver:
                ItemSprite = Resources.Load<Sprite>("Inventory/Screwdriver");
                break;
            case ItemType.Statue:
                ItemSprite = Resources.Load<Sprite>("Inventory/Statue");
                break;
            default:
                ItemSprite = Resources.Load<Sprite>("Inventory/Empty");
                break;
        }
        IsEquipped = false;
        IsRemovable = isRemovable;
    }

    /// <summary>
    /// Used for debug
    /// </summary>
    /// <returns>string with all the Item info</returns>
    public string GetInfo()
    {
        return TypeOfItem + " " + IsEquipped + " " + IsRemovable + " " + ItemSprite;
    }
}
