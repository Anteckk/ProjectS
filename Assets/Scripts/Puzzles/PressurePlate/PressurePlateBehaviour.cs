using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehaviour : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] bool isSteppedOn;

    public List<GameObject> objectsList = new List<GameObject>();

    [SerializeField] PressurePlateBehaviour otherPlate;
    [SerializeField] GameObject ClosedDoor;
    [SerializeField] private GameObject OpenDoor;
    [SerializeField] GameObject statue;
    [SerializeField] GameObject lightPoint;


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
        ChangePlateState();
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
        if (!other.gameObject.GetComponent<InteractionRangeBehaviour>())
        {
             objectsList.Add(other.gameObject);
        }

        if (isActive)
        {
            ChangePlateState();
            CheckPlates();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectsList.Remove(other.gameObject);
        Debug.Log("removed");
        if (isActive)
        {
            ChangePlateState();
        }
    }

    public void ChangePlateState()
    {
        Debug.Log(objectsList.Count);
        if (objectsList.Count == 0)
        {
            isSteppedOn = false;
            lightPoint.GetComponent<Light>().color = Color.red;
        }
        else
        {
            isSteppedOn = true;
            lightPoint.GetComponent<Light>().color = Color.green;
        }
    }

    public void CheckPlates()
    {
        Debug.Log("CheckPlates");
        if (otherPlate.getIsSteppedOn() && getIsSteppedOn())
        {
            if (ClosedDoor.activeSelf)
            {
                ClosedDoor.SetActive(false);
                OpenDoor.SetActive(true);
            }
            
            Debug.Log("Spawn");
            GameObject statueInstance = Instantiate(statue, new Vector3(-25, 35, -4),new Quaternion(0,0,0,1));

            var script = statueInstance.GetComponent<StatueScript>();
            if (!script.getIsPickup())
            {
               
                script.setIsPickup(true);
                script.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public void ActiveLight()
    {
        lightPoint.GetComponent<Light>().intensity = 1;
    }
}