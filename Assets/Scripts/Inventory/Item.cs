using System;
using UnityEngine;

public class Item 
{
    //Add item type here
    public enum ItemType
    {
        //TODO: Add more thing later (VS)
        Screwdriver, Statue,
    }

    public ItemType TypeOfItem;
    public readonly Sprite ItemSprite;
    public bool IsEquipped;
    public bool IsRemovable;

    /// <summary>
    /// Constructor
    /// </summary>
    public Item(ItemType typeOfItem, bool isRemovable)
    {
        TypeOfItem = typeOfItem;
        //If you add another item type need to add it to the constructor
        switch (TypeOfItem)
        {
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
}
