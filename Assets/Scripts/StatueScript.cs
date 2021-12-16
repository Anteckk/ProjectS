using UnityEngine;

public class StatueScript : Interactable
{
    private GameObject player;
    private Item self;

    public bool isPickup;
    // Start is called before the first frame update
    void Start()
    {
        self = new Item(Item.ItemType.Statue, true);
        player = GameObject.Find("Player");
        if (GameManager.instance.statuetteIsPickedUp)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
    }
    
    /// <summary>
    /// The action associated to this item
    /// </summary>
    public override void action()
    {
        StatuePickup();
    }

    public void setIsPickup(bool prmIsPickup)
    {
        isPickup = prmIsPickup;
    }

    public bool getIsPickup()
    {
        return isPickup;
    }

    private void StatuePickup()
    {
        if (isPickup)
        {
            GameManager.instance.GetPlayerInventory().AddItem(self);
            GameManager.instance.statuetteIsPickedUp = true;
            player.GetComponent<PlayerController>().getInventoryWheelController().RefreshUIItem();
            gameObject.SetActive(false);
            player.GetComponentInChildren<Canvas>().enabled = false;
        }
    }
}
