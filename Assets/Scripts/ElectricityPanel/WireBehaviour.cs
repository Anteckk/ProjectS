using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WireBehaviour : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] GameObject cablePart;
    [SerializeField] GameObject doorPanel;
    private Rigidbody rb;
    private bool hasGoodPlace;
    private GameObject cablePlace;
    private GameObject player;
    
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
        player = GameObject.FindWithTag("Player");
    }

    public void OnMouseDrag()
    {
        if (!player.GetComponent<PlayerController>().isItSherlock() && doorPanel.GetComponent<ElectricityDoor>().IsOpen())
        {
            // We take the mouse position to know were is the cable to update his transform
            Vector3 newPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = cablePart.transform.position.z;

            // Update rotation
            transform.position = (startPosition + newPosition) / 2;
            Vector3 temp = newPosition - startPosition;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, temp);

            //update scale of cable
            float dist = Vector3.Distance(startPosition, newPosition);
            transform.localScale = new Vector3(transform.localScale.x, dist, transform.localScale.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CablePlace"))
        {
            if (!other.GetComponent<CablePlaceBehaviour>().haveCable())
            {
                cablePlace = other.gameObject;
                Debug.Log(gameObject.name);
                Debug.Log(name);
                cablePlace.GetComponent<CablePlaceBehaviour>().occupe(name);
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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CablePlace")
        {
            if (other.GetComponent<CablePlaceBehaviour>().getCableName() == name)
            {
                other.GetComponent<CablePlaceBehaviour>().free();
                cablePlace = null;
            }
        }
    }

    void OnMouseUp()
    {
        if (cablePlace != null)
        {
            transform.position = (cablePlace.transform.position + startPosition)/2;
            float dist = Vector3.Distance(startPosition, cablePlace.transform.position);
            transform.localScale = new Vector3(transform.localScale.x, dist, transform.localScale.z);
            cablePlace.GetComponentInChildren<CablePlaceBehaviour>().PlayParticle();
        }
        else
        {
            transform.position = startPosition;
            transform.localScale = startLocalScale;
            transform.rotation = Quaternion.Euler(90,90,0);
        }
    }

    public bool idGoodPlaced()
    {
        return hasGoodPlace;
    }
}