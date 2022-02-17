using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryWheelController : MonoBehaviour
    {
        public Animator anim;
        public Image raycastBlocker;
        public Image selectedItem;
        public static int itemID;
        public bool inventoryWheelSelected = false;
        private Sprite blankIcon;
        private PlayerController playerController;

        private void Awake()
        {
            blankIcon = Resources.Load<Sprite>("Inventory/Empty");
        }

        private void Update()
        {
            //Show/Hide inventory animation
            anim.SetBool("OpenInventoryWheel", inventoryWheelSelected);
            raycastBlocker.enabled = inventoryWheelSelected;
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
        public void ToggleInventory()
        {
            inventoryWheelSelected = !inventoryWheelSelected;
        }
    }
}
