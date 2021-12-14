using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressurePlateBehaviour : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] bool isSteppedOn;

    private List<GameObject> objectsList = new List<GameObject>();

    [SerializeField] PressurePlateBehaviour otherPlate;
    [SerializeField] DoorControler doorBehaviour;
    [SerializeField] StatueScript statueScript;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (objectsList.Count == 0)
        {
            isSteppedOn = false;
        }
        else
        {
            isSteppedOn = true;
        }
    }

    public void setIsActive(bool prmIsActive)
    {
        isActive = prmIsActive;
    }

    public bool getIsActive()
    {
        return isActive;
    }

    public bool getIsSteppedOn()
    {
        return isSteppedOn;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        objectsList.Add(other.gameObject);
        Debug.Log("added");
        foreach (GameObject go in objectsList)
        {
            Debug.Log(go.name);
        }
        checkPlates();
    }

    private void OnTriggerExit(Collider other)
    {
        objectsList.Remove(other.gameObject);
        Debug.Log("removed");
    }

    public void checkPlates()
    {
        if (otherPlate.getIsSteppedOn() && getIsSteppedOn())
        {
            if (!doorBehaviour.getIsActive())
            {
               doorBehaviour.SetIsActive(true);
            } 
            if (!statueScript.getIsPickup())
            {
                statueScript.setIsPickup(true);
            }
        }
    }
    
}