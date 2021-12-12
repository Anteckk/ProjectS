using UnityEngine;

public class StatueScript : Interactable
{
    private GameObject player;
    private Item self;
    private GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        self = new Item(Item.ItemType.Statue, true);
        player = GameObject.Find("Player");
        door = GameObject.Find("Door");
    }
    /// <summary>
    /// The action associated to this item
    /// </summary>
    public override void action()
    {
        StatuePickup();
    }

    private void StatuePickup()
    {
        player.GetComponent<PlayerController>().getPlayerInventory().AddItem(self);
        player.GetComponent<PlayerController>().getInventoryWheelController().RefreshUIItem();
        door.GetComponent<DoorControler>().SetIsActive(true);
        gameObject.SetActive(false);
    }
}
