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
        private Sprite blankIcon;
        private bool inventoryWheelSelected = false;
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
        public void ShowInventory()
        {
            inventoryWheelSelected = !inventoryWheelSelected;
            Debug.Log("InventoryWheelSelected = " + inventoryWheelSelected.ToString());
        }
    }
}
