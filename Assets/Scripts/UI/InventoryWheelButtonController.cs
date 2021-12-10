using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class InventoryWheelButtonController : MonoBehaviour
    {
        public int iD;
        public TextMeshProUGUI itemText;
        public Image selectedItem;
        public Image icon;
        
        private PlayerController playerController;
        private Animator anim;
        private Sprite blankIcon;
        private void Awake()
        {
            playerController = FindObjectOfType<PlayerController>();
            blankIcon = Resources.Load<Sprite>("Inventory/Empty");
            anim = GetComponent<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
            //If button iD is higher than current player inventory size Disableinteraction()
            //Else show the sprite of the item
            if (iD >= playerController.getPlayerInventory().GetInventorySize())
            {
                DisableInteraction();
            }
            else
            {
                icon.sprite = playerController.getPlayerInventory().GetItem(iD).ItemSprite;
            }
        }
        
        /// <summary>
        /// When player click the button
        /// </summary>
        public void Selected()
        {
            InventoryWheelController.itemID = iD;
            playerController.getPlayerInventory().SetItemEquipped(iD);
            selectedItem.sprite = playerController.getPlayerInventory().GetItem(iD).ItemSprite;
        }
        /// <summary>
        /// When player click something else
        /// </summary>
        public void Deselected()
        {
            InventoryWheelController.itemID = -1;
            playerController.getPlayerInventory().UnequipItem();
        }
        /// <summary>
        /// When mouse is over the button
        /// </summary>
        public void HoverEnter()
        {
            anim.SetBool("Hover", true);
            if (iD < playerController.getPlayerInventory().GetInventorySize())
            {
                itemText.text = playerController.getPlayerInventory().GetItem(iD).TypeOfItem.ToString();
            }
        }
        /// <summary>
        /// When mouse isn't over the button anymore
        /// </summary>
        public void HoverExit()
        {
            anim.SetBool("Hover", false);
            itemText.text = "";
        }

        /// <summary>
        /// Refresh the button sprite/interactibility. Use this when removing an item to update the inventory.
        /// Called by RefreshUIInventory from InventoryWheelController
        /// </summary>
        public void RefreshButton()
        {
            if (iD >= playerController.getPlayerInventory().GetInventorySize())
            {
                DisableInteraction();
            }
            else
            {
                icon.sprite = playerController.getPlayerInventory().GetItem(iD).ItemSprite;
                GetComponent<Button>().interactable = true;
            }
        }
        
        /// <summary>
        /// Disable the interaction/Hide the sprite.
        /// </summary>
        private void DisableInteraction()
        {
            GetComponent<Button>().interactable = false;
            icon.sprite = blankIcon;
            selectedItem.sprite = blankIcon;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        }
    }
}
