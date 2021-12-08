using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    /// <summary>
    /// Constructor
    /// </summary>
    public Inventory()
    {
        itemList = new List<Item>();
        //TODO: Fix to not have item added directly to inventory (release)
        AddItem(new Item { itemType = Item.ItemType.Screwdriver, itemSprite = Resources.Load<Sprite>("Inventory/Screwdriver")});
        AddItem(new Item { itemType = Item.ItemType.Statuette, itemSprite = Resources.Load<Sprite>("Inventory/Statue")});
        Debug.Log(itemList);
    }

    /// <summary>
    /// Add an Item to the list
    /// Do not forget to call the function RefreshUIItem from InventoryWheelButtonController after calling this
    /// </summary>
    /// <param name="item">the Item to add to the list</param>
    public void AddItem(Item item)
    {
        item.isEquipped = false;
        itemList.Add(item);
    }
    
    /// <summary>
    /// Search the currently equipped item, and then unequip it
    /// </summary>
    public void UnequipItem()
    {
        if (itemList.Exists(x => x.isEquipped = true))
        {
            itemList.Find(x => x.isEquipped = true).isEquipped = false;
        }
    }
    
    /// <summary>
    /// Search the currently equipped item, and then remove it from the list
    /// Do not forget to call the function RefreshUIItem from InventoryWheelButtonController after calling this
    /// </summary>
    public void RemoveEquippedItem()
    {
        if (itemList.Exists(x => x.isEquipped = true))
        {
            itemList.Remove(itemList.Find(x => x.isEquipped = true));
        }
    }

    #region Getter
    public int GetInventorySize()
    {
        return itemList.Count;
    }

    public Item GetItem(int index)
    {
        return itemList[index];
    }

    public List<Item> GetList()
    {
        return itemList;
    }
    #endregion

    #region Setter
    public void SetItemEquipped(int index)
    {
        itemList[index].isEquipped = true;
    }
    #endregion

}
