using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        //TODO: Add more thing later (VS)
        Screwdriver,
    }

    public ItemType itemType;
    public bool isEquipped;
    public Sprite itemSprite;
}
