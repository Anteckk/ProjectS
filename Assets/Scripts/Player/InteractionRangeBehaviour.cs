using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionRangeBehaviour : MonoBehaviour
{
    private Interactable interactableObject;
    private GameObject triggeredObject;

    public Canvas InteractioncanCanvas;
    public TMP_Text InteractedObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InteractioncanCanvas.transform.LookAt(Camera.main.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.gameObject.GetComponent<Interactable>();
        triggeredObject = other.gameObject;

        if (interactable != null)
        {
            interactableObject = interactable;
            Debug.Log("In Range");

            InteractioncanCanvas.enabled = true;
            InteractedObject.SetText(interactable.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(triggeredObject))
        {
            interactableObject = null;
            Debug.Log("Not in Range");

            InteractioncanCanvas.enabled = false;
        }
    }

    public Interactable getInteractableObject()
    {
        return interactableObject;
    }
}