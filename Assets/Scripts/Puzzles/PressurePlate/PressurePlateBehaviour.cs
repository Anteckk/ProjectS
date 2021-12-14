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
    }

    public void setIsActive(bool prmIsActive)
    {
        isActive = prmIsActive;
        changePlateState();
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

        if (isActive)
        {
            checkPlates();
            changePlateState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectsList.Remove(other.gameObject);
        Debug.Log("removed");
        if (isActive)
        {
            changePlateState();
        }
    }

    private void changePlateState()
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
                statueScript.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}