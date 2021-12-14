using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ElectricityPanel : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] List<Material> cableMaterials;
    [SerializeField] List<GameObject> cableList;
    [SerializeField] List<GameObject> cablePlaceList;
    [SerializeField] List<GameObject> wireList;
    private RaycastHit hit;
    private bool doorOpen;
    private int layerMask;
    private Ray ray;
    private int screwsUnscrewed = 0;
    private List<GameObject> redObjects;

    private void Start()
    {
        layerMask = 1 << 10;
        doorOpen = false;
        redObjects = new List<GameObject>();
        initCable();
    }


    // Here we initialize the random color of the cables and the places of cables
    private void initCable()
    {
        var rand = new Random();
        var randomList = cableMaterials.OrderBy(x => rand.Next()).ToList();
        cableMaterials = randomList;

        for (int i = 0; i < cableList.Count; i++)
        {
            if (cableMaterials[i].color.Equals(Color.red))
            {
                Debug.Log("red object + " + cableList[i].gameObject);
                redObjects.Add(
                    cableList[i].gameObject
                    );
                redObjects.Add(wireList[i].gameObject);
            }
            cableList[i].GetComponent<MeshRenderer>().material.color = cableMaterials[i].color;
            wireList[i].GetComponent<MeshRenderer>().material.color = cableMaterials[i].color;
        }
        
        randomList = cableMaterials.OrderBy(x => rand.Next()).ToList();
        cableMaterials = randomList;

        for (int i = 0; i < cablePlaceList.Count; i++)
        {
            
            if (cableMaterials[i].color.Equals(Color.red))
            {
                redObjects.Add(cablePlaceList[i].gameObject);
            }
            cablePlaceList[i].GetComponent<MeshRenderer>().material.color = cableMaterials[i].color;
        }
    }

    public void OpenDoor()
    {
        doorOpen = true;
    }

    public bool isDoorOpen()
    {
        return doorOpen;
    }

    public List<GameObject> getRedObjects()
    {
        return redObjects;
    }
}
