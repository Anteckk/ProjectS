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

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
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

        if (!_playerController.isItSherlock() && other.gameObject.GetComponent<PressurePlateBehaviour>())
        {
            other.GetComponent<PressurePlateBehaviour>().objectDialogue.TriggerDialogue();
        }
        
        if (interactable != null)
        {
            interactableObject = interactable;
            Debug.Log("In Range");
            if (interactable.isGoodPlayer())
            {
                InteractioncanCanvas.enabled = true;
                InteractedObject.SetText(interactable.gameObject.name);
            }
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