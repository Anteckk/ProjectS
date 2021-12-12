using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryWheelController : MonoBehaviour
    {
        public Animator anim;
        public Image selectedItem;
        public static int itemID;
        private Sprite blankIcon;
        private bool inventoryWheelSelected = false;
        private PlayerController playerController;

        private void Awake()
        {
            blankIcon = Resources.Load<Sprite>("Inventory/Empty");
            playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            //Show/Hide inventory animation
            anim.SetBool("OpenInventoryWheel", inventoryWheelSelected);

            //Do something when an item is selected (TBD)
            //TODO: Do something idk
            /*switch (itemID)
            {
                case -1: //Nothing is selected
                    selectedItem.sprite = blankIcon;
                    break;
                case 0://Item Slot 1
                    break;
                case 1: //Item Slot 2
                    break;
                case 2: //Item Slot 3
                    break;
                case 3: //Item Slot 4
                    break;
                case 4: //Item Slot 5
                    break;
                case 5: //Item Slot 6
                    break;
                case 6: //Item Slot 7
                    break;
                case 7: //Item Slot 8
                    break;  
            }*/
        }
        /// <summary>
         /// /!\ CALL THIS WHENEVER YOU ADD/REMOVE ITEM from inventory /!\
         /// </summary>
        public void RefreshUIItem()
        {
            foreach (InventoryWheelButtonController x in transform.GetComponentsInChildren<InventoryWheelButtonController>())
            {
                    x.RefreshButton();
            }
        }
        /// <summary>
        /// Show/Hide the inventory
        /// </summary>
        public void ShowInventory()
        {
            inventoryWheelSelected = !inventoryWheelSelected;
        }
    }
}
