using UnityEngine;

public class ValveMechanics : Interactable
{
    [SerializeField] private GameObject GasCloud;

    private PlayerController PC;

    [SerializeField]  DialogueTrigger objectSherlockDialogue;
    [SerializeField]  DialogueTrigger objectWatsonDialogue;

    // Start is called before the first frame update
    void Start()
    {
        PC = FindObjectOfType<PlayerController>();
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
            if (PC.isItSherlock())
            {
                objectSherlockDialogue.TriggerDialogue();;
            }
            else
            {
                objectWatsonDialogue.TriggerDialogue();
            }
        }
        else
        {
            GasCloud.SetActive(true);
            Debug.Log("Gas on");
        }
    }
}