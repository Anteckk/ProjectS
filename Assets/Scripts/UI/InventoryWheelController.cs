using System;
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
            //When the player press Tab Show/Hide inventory
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventoryWheelSelected = !inventoryWheelSelected;
            }

            //Show/Hide inventory animation
            if (inventoryWheelSelected)
            {
                anim.SetBool("OpenInventoryWheel", true);
            }
            else
            {
                anim.SetBool("OpenInventoryWheel", false);
            }

            //Do something when an item is selected (TBD)
            //TODO: Do something idk
            switch (itemID)
            {
                case -1: //Nothing is selected
                    selectedItem.sprite = blankIcon;
                    break;
                case 0://Screwdriver
                    break;
                case 1: //Item
                    break;
                case 2: //Item
                    break;
                case 3: //Item
                    break;
                case 4: //Item
                    break;
                case 5: //Item
                    break;
                case 6: //Item
                    break;
                case 7: //Item
                    break;  
            }
            //TODO: Remove this, DEBUG
            if (Input.GetKeyDown(KeyCode.P))
            {
                playerController.getPlayerInventory().RemoveEquippedItem();
                this.transform.GetChild(itemID).GetComponent<InventoryWheelButtonController>().DisableInteraction();
            }
        }
    }
}
