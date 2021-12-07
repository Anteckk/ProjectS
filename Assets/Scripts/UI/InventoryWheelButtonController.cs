using TMPro;
using UnityEngine;
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
        private int currentPlayerInventorySize;
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
            //Set max size to have button interactable
            currentPlayerInventorySize = playerController.getPlayerInventory().GetInventorySize();
            //If button iD is higher than current player inventory size Disableinteraction()
            //Else show the sprite of the item
            if (iD >= currentPlayerInventorySize)
            {
                DisableInteraction();
            }
            else
            {
                icon.sprite = playerController.getPlayerInventory().GetItem(iD).itemSprite;
            }
        }
        
        /// <summary>
        /// When player click the button
        /// </summary>
        public void Selected()
        {
            InventoryWheelController.itemID = iD;
            playerController.getPlayerInventory().SetItemEquipped(iD);
            selectedItem.sprite = playerController.getPlayerInventory().GetItem(iD).itemSprite;
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
            if (iD < currentPlayerInventorySize)
            {
                itemText.text = playerController.getPlayerInventory().GetItem(iD).itemType.ToString();
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
        /// Disable the interaction/Hide the sprite. Use this when removing item
        /// </summary>
        public void DisableInteraction()
        {
            GetComponent<Button>().interactable = false;
            icon.sprite = blankIcon;
            selectedItem.sprite = blankIcon;
            currentPlayerInventorySize = playerController.getPlayerInventory().GetInventorySize();
        }

    }
}
