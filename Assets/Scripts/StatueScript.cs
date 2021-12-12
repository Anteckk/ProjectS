using UnityEngine;

public class StatueScript : Interactable
{
    private GameObject player;
    private Item self;
    private GameObject door;

    public PressurePlateBehaviour[] plates;

    public bool isPickup;
    // Start is called before the first frame update
    void Start()
    {
        self = new Item(Item.ItemType.Statue, true);
        player = GameObject.Find("Player");
        door = GameObject.Find("Door");
    }

    void Update()
    {
        int activated = 0;
        
        foreach (PressurePlateBehaviour plates in plates)
        {
            if (plates.getIsSteppedOn())
            {
                activated++;
            }
        }

        if (activated == plates.Length)
        {
            isPickup = true;
        }
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
        if (isPickup)
        {
            player.GetComponent<PlayerController>().getPlayerInventory().AddItem(self);
            player.GetComponent<PlayerController>().getInventoryWheelController().RefreshUIItem();
            door.GetComponent<DoorControler>().SetIsActive(true);
            gameObject.SetActive(false);
            
        }
    }
}
