using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class PressurePlateBehaviour : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] bool isSteppedOn;

    public List<GameObject> objectsList = new List<GameObject>();

    [SerializeField] PressurePlateBehaviour otherPlate;
    [SerializeField] PlayableDirector StatuetteCinematic;
    [SerializeField] GameObject ClosedDoor;
    [SerializeField] private GameObject OpenDoor;
    [SerializeField] GameObject statue;
    [SerializeField] GameObject lightPoint;
    [SerializeField] public DialogueTrigger objectDialogue;
    [SerializeField] private NavMeshObstacle NavMeshObstacle;


    // Start is called before the first frame update
    void Start()
    {

        NavMeshObstacle = GetComponent<NavMeshObstacle>();

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
        //Debug.Log("removed");
        if (isActive)
        {
            ChangePlateState();
        }
    }

    public void ChangePlateState()
    {
        //Debug.Log(objectsList.Count);
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
        //Debug.Log("CheckPlates");
        if (otherPlate.getIsSteppedOn() && getIsSteppedOn())
        {
            if (ClosedDoor.activeSelf)
            {
                StatuetteCinematic.Play();
                ClosedDoor.SetActive(false);
                OpenDoor.SetActive(true);
            }
        }
    }

    public void ActiveLight()
    {
        lightPoint.GetComponent<Light>().intensity = 1;
    }

    public void togglePlates(bool prmIsSherlock)
    {
        if (prmIsSherlock && NavMeshObstacle.enabled)
        {
            NavMeshObstacle.enabled = false;
        }
        else
        {
            NavMeshObstacle.enabled = true;
        }
    }
    
}