using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObjet : Interactable
{

    private bool isTake;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public override void action()
    {
        if (isTake)
        {
            Debug.Log("release");
            release();
        }
        else
        {
            Debug.Log("take");
            take();
        }
    }


    private void release()
    {
        Debug.Log("release crate");
        isTake = false;
        player.GetComponent<PlayerController>().releaseCrate();

        transform.parent = null;
    }

    private void take()
    {
        if (!player.GetComponent<PlayerController>().isItSherlock())
        {
            isTaken();
            Debug.Log("take crate");
            player.GetComponent<PlayerController>().TakeCrate();
            player.GetComponent<PlayerController>().removeFromPlate(gameObject);
            Destroy(gameObject);
        }
    }

    public void isTaken()
    {
        isTake = true;
    }

    public bool objectIsTaken()
    {
        return isTake;
    }
}
