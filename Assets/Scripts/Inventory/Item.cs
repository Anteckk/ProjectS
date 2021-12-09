using UnityEngine;

public class Item 
{
    //Add item type here
    public enum ItemType
    {
        //TODO: Add more thing later (VS)
        Screwdriver, Statue,
    }

    public ItemType itemType;
    public bool isEquipped;
    public Sprite itemSprite;
}
