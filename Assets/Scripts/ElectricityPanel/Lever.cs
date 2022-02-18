using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Lever : MonoBehaviour
{
    
    [SerializeField] List<GameObject> wireList;
    [SerializeField] GameObject objectToBeActived;
    private GameObject player;

    [SerializeField] DialogueTrigger objectSuccessDialogue;
    [SerializeField] DialogueTrigger objectFailWatsonDialogue;
    [SerializeField] DialogueTrigger objectFailSherlockDialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Ui is blocking");
            return;
        }
        Debug.Log(checkWires());
        if (checkWires())
        {
            player.GetComponent<PlayerController>().OnBack();
            objectSuccessDialogue.TriggerDialogue();
        }
        else
        {
            objectFailWatsonDialogue.TriggerDialogue();
        }
    }
    
    
    public bool checkWires()
    {
        bool result = true;

        foreach (var wire in wireList)
        {
            result = result && wire.GetComponentInParent<WireBehaviour>().idGoodPlaced();
        }

        if (result)
        {
            objectToBeActived.GetComponent<PressurePlateBehaviour>().setIsActive(true);
            objectToBeActived.GetComponent<PressurePlateBehaviour>().ActiveLight();
        }
        else
        {
            objectToBeActived.GetComponent<PressurePlateBehaviour>().setIsActive(false);
        }


        
        return result;
    }
}
