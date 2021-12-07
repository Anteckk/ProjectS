using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWheelController : MonoBehaviour
{
    public Animator anim;
    public Image selectedItem;
    public Sprite noImage;
    public static int itemID;

    private PlayerController playerController;
    private bool inventoryWheelSelected = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryWheelSelected = !inventoryWheelSelected;
        }

        if (inventoryWheelSelected)
        {
            anim.SetBool("OpenInventoryWheel", true);
        }
        else
        {
            anim.SetBool("OpenInventoryWheel", false);
        }

        switch (itemID)
        {
            case -1: //Nothing is selected
                selectedItem.sprite = noImage;
                setPlayerEquipped(itemID);
                break;
            case 0://Screwdriver
                //TODO: Do something idk
                setPlayerEquipped(itemID);
                Debug.Log("Screwdriver");
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
    }

    //Set/Unset Equipement du joueur
    private void setPlayerEquipped(int index)
    {
        if (index == -1)
        {
            playerController.getPlayerInventory().UnequipItem();
        }
        else
        {
            playerController.getPlayerInventory().SetItemEquipped(index);
        }
    }
}
