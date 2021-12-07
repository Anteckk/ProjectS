using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        //TODO: Fix to not have item added directly to inventory (release)
        AddItem(new Item { itemType = Item.ItemType.Screwdriver});
    }

    public void AddItem(Item item)
    {
        item.isEquipped = false;
        itemList.Add(item);
    }

    public void UnequipItem()
    {
        if (itemList.Exists(x => x.isEquipped = true))
        {
            itemList.Find(x => x.isEquipped = true).isEquipped = false;
        }
    }

    public void SetItemEquipped(int index)
    {
        itemList[index].isEquipped = true;
    }

    public int getInventorySize()
    {
        return itemList.Count;
    }

    public Item getItem(int index)
    {
        return itemList[index];
    }
}
