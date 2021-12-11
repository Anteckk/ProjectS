using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueScript : MonoBehaviour
{
    private GameObject player;
    private Item self;
    // Start is called before the first frame update
    void Start()
    {
        self = new Item(Item.ItemType.Statue, true);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //SqrMagnite<3*3 -> Set the range to notice the player at 3 unit
        if ((player.transform.position - transform.position).sqrMagnitude<3*3)
        {
            player.GetComponent<PlayerController>().getPlayerInventory().AddItem(self);
            enabled = false;
            Destroy(gameObject);
            Debug.Log("Near");
        }
    }
}
