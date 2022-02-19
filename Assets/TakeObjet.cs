using UnityEngine;

public class TakeObjet : Interactable
{
    private bool isTake;

    private GameObject player;
    [SerializeField] DialogueTrigger objectDialogue;

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
    public override bool isGoodPlayer()
    {
        if (!player.GetComponent<PlayerController>().isItSherlock())
        {
            return true;
        }
        return false;
    }

    private void release()
    {
        Debug.Log("release crate");
        isTake = false;
        player.GetComponent<PlayerController>().ReleaseCrate();

        transform.parent = null;
    }

    private void take()
    {
        if (!player.GetComponent<PlayerController>().isItSherlock())
        {
            isTaken();
            Debug.Log("take crate");
            player.GetComponent<PlayerController>().TakeCrate();
            player.GetComponent<PlayerController>().RemoveFromPlate(gameObject);
            Destroy(gameObject);
        }
        else
        {
            if (objectDialogue != null)
            {
                objectDialogue.TriggerDialogue();
            }
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