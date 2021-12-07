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
        foreach (Item item in itemList)
        {
            item.isEquipped = false;
        }
        Debug.Log(itemList[0].itemType);
    }

    public void AddItem(Item item)
    {
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
        UnequipItem();
        itemList[index].isEquipped = true;
        Debug.Log(itemList.Find(x => x.isEquipped=true));
    }
}
