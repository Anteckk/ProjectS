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
    
        /// <summary>
        /// Search the currently equipped item, and then unequip it
        /// </summary>
        public void UnequipItem()
        {
            if (_itemList.Exists(x => x.IsEquipped = true))
            {
                _itemList.Find(x => x.IsEquipped = true).IsEquipped = false;
            }
        }
    
        /// <summary>
        /// Search the currently equipped item, and then remove it from the list
        /// Do not forget to call the function RefreshUIItem from InventoryWheelButtonController after calling this
        /// </summary>
        public bool RemoveEquippedItem()
        {
            if (_itemList.Exists(x => x.IsEquipped == true && x.IsRemovable == true))
            {
                _itemList.Remove(_itemList.Find(x => x.IsEquipped == true && x.IsRemovable == true));
                return true;
            }

            return false;
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

        public List<Item> GetList()
        {
            return _itemList;
        }
        #endregion

        #region Setter
        public void SetItemEquipped(int index)
        {
            _itemList[index].IsEquipped = true;
        }
        #endregion

    }
}
