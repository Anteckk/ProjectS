using System;
using UnityEngine;

public class TakeObjet : Interactable
{
    private bool isTake;

    private PlayerController player;
    [SerializeField] DialogueTrigger objectDialogue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
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
    public override bool isGoodPlayer()
    {
        if (!player.isItSherlock())
        {
            return true;
        }
        return false;
    }

    private void release()
    {
        Debug.Log("release crate");
        isTake = false;
        player.ReleaseCrate();

        player.Hand.transform.DetachChildren();
    }

    private void take()
    {
        if (!player.isItSherlock())
        {
            isTaken();
            
            Debug.Log("take crate");
            player.TakeCrate();
            player.RemoveFromPlate(gameObject);
            
            
            transform.SetParent(player.Hand.transform);
            transform.SetPositionAndRotation(player.Hand.transform.position, player.Hand.transform.rotation); 

        }
        else
        {
            if (objectDialogue != null)
            {
                objectDialogue.TriggerDialogue();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isTake)
        {
            release();
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