using UnityEngine;

public class ValveMechanics : Interactable
{
    [SerializeField] private GameObject GasCloud;

    [SerializeField] public DialogueTrigger objectDialogue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public override void action()
    {
        gasControl();
    }

    public override bool isGoodPlayer()
    {
        // Here we return true because we didn't care about which character we played
        return true;
    }

    public void gasControl()
    {
        if (GasCloud.active)
        {
            GasCloud.SetActive(false);
            Debug.Log("Gas off");
            objectDialogue.TriggerDialogue();
        }
        else
        {
            GasCloud.SetActive(true);
            Debug.Log("Gas on");
        }
    }
}