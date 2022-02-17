using System.Collections.Generic;



namespace Inventory
{
    public class Inventory
    {
        private readonly List<Item> _itemList;

        /// <summary>
        /// Constructor
        /// </summary>
        public Inventory()
        {
            _itemList = new List<Item>();
        }

        /// <summary>
        /// Add an Item to the list
        /// Do not forget to call the function RefreshUIItem from InventoryWheelButtonController after calling this
        /// </summary>
        /// <param name="item">the Item to add to the list</param>
        public void AddItem(Item item)
        {
            _itemList.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (_itemList.Contains(item))
            {
                _itemList.Remove(item);
            }
        }
    
        /// <summary>
        /// 
        /// </summary>
        public void UnequipItem()
        {
            
        }
    
        /// <summary>
        /// Search the currently equipped item, and then remove it from the list
        /// Do not forget to call the function RefreshUIItem from InventoryWheelButtonController after calling this
        /// </summary>
        public void RemoveEquippedItem()
        {
            if (_itemList.Exists(x => x.IsEquipped == true && x.IsRemovable == true))
            {
                _itemList.Remove(_itemList.Find(x => x.IsEquipped == true && x.IsRemovable == true));
            }
        }

        #region Getter
        public int GetInventorySize()
        {
            return _itemList.Count;
        }

        public Item GetItem(int index)
        {
            return _itemList[index];
        }

        public Item GetEquippedItem()
        {
            if (_itemList.Exists(x => x.IsEquipped == true))
            {
                return _itemList.Find(x => x.IsEquipped == true);
            }
            else
            {
                return new Item(Item.ItemType.Empty, false);
            }
        }
        /// <summary>
        /// Mostly used for debug
        /// </summary>
        /// <returns></returns>
        public List<Item> getItemList()
        {
            return _itemList;
        }
        #endregion

        #region Setter
        /// <summary>
        /// Search for the currently equipped item, and then unequip it, then equip the new item
        /// </summary>
        /// <param name="index"></param>
        public void SetItemEquipped(int index)
        {
            if (_itemList.Exists(x => x.IsEquipped == true))
            {
                _itemList.Find(x => x.IsEquipped == true).IsEquipped = false;
            }
            _itemList[index].IsEquipped = true;
        }
        #endregion

    }
}
