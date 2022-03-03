using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasScript : MonoBehaviour
{
    [SerializeField] public DialogueTrigger objectSherlockDialogue;
    [SerializeField] public DialogueTrigger objectWatsonDialogue;
    
    private PlayerController PC;

    private void Start()
    {
        PC = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PC.isItSherlock())
        {
            objectSherlockDialogue.TriggerDialogue();
        }
        else
        {
            objectWatsonDialogue.TriggerDialogue();
        }
    }
}
