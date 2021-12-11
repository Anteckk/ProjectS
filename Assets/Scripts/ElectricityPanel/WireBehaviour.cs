using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WireBehaviour : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] GameObject cablePart;
    [SerializeField] GameObject panel;
    private Rigidbody rb;
    private bool hasGoodPlace;
    private GameObject cablePlace;
    
    private Vector3 startPosition;
    private Vector3 startLocalScale;
    private Vector3 center;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hasGoodPlace = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = cablePart.transform.parent.position;
        startLocalScale = transform.localScale;
    }

    public void OnMouseDrag()
    {
        // We take the mouse position to know were is the cable to update his transform
        Vector3 newPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = cablePart.transform.position.z;

        // Update rotation
        transform.position = (startPosition + newPosition)/2;
        Vector3 temp = newPosition - startPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward,temp);
        
        //update scale of cable
        float dist = Vector3.Distance(startPosition, newPosition);
        transform.localScale = new Vector3(transform.localScale.x, dist, transform.localScale.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeshRenderer>() != null)
        {
            cablePlace = other.gameObject;
            if (other.GetComponent<MeshRenderer>().material.color == cablePart.GetComponent<MeshRenderer>().material.color)
            {
                hasGoodPlace = true;
            }
            else
            {
                hasGoodPlace = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        cablePlace = null;
    }

    void OnMouseUp()
    {
        if (cablePlace != null)
        {
            transform.position = (cablePlace.transform.position + startPosition)/2;
            float dist = Vector3.Distance(startPosition, cablePlace.transform.position);
            transform.localScale = new Vector3(transform.localScale.x, dist, transform.localScale.z);
        }
        else
        {
            transform.position = startPosition;
            transform.localScale = startLocalScale;
        }
    }

    public bool idGoodPlaced()
    {
        return hasGoodPlace;
    }
}