using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ValveMechanics : Interactable
{
    [SerializeField] PlayableDirector GasOffCinematic;
    [SerializeField] PlayableDirector GasOnCinematic;

    private PlayerController playerController;

    [SerializeField]  DialogueTrigger objectSherlockDialogue;
    [SerializeField]  DialogueTrigger objectWatsonDialogue;
    private bool isActive;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        isActive = true;
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
        if (isActive)
        {
            GasOffCinematic.Play();
            Debug.Log("Gas off");
            isActive = false;
            if (playerController.isItSherlock())
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
            GasOnCinematic.Play();
            isActive = true;
            Debug.Log("Gas on");
        }
    }
}