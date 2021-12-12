using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRangeBehaviour : MonoBehaviour
{

    private Interactable interactableObject;
    private GameObject triggeredObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.gameObject.GetComponent<Interactable>();
        triggeredObject = other.gameObject;
        
        if ( interactable != null)
        {
            interactableObject = interactable;
            Debug.Log("In Range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(triggeredObject))
        {
            interactableObject = null;
            Debug.Log("Not in Range");
        }
    }

    public Interactable getInteractableObject()
    {
        return interactableObject;
    }
}
