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
    private RaycastHit hit;
    private int layerMask;
    private Ray ray;
    private int screwsUnscrewed = 0;

    private void Start()
    {
        layerMask = 1 << 10;
        initCable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit.collider.name);
                hit.transform.gameObject.GetComponent<ScrewScript>().GetHit();
            }
            else
            {
                Debug.Log("Didn't hit shit");
            }
        }
    }

    private void initCable()
    {
        var rand = new Random();
        var randomList = cableMaterials.OrderBy(x => rand.Next()).ToList();
        cableMaterials = randomList;

        for (int i = 0; i < cableList.Count; i++)
        {
            cableList[i].GetComponent<MeshRenderer>().material.color = cableMaterials[i].color;
        }
        
        randomList = cableMaterials.OrderBy(x => rand.Next()).ToList();
        cableMaterials = randomList;

        for (int i = 0; i < cablePlaceList.Count; i++)
        {
            cablePlaceList[i].GetComponent<MeshRenderer>().material.color = cableMaterials[i].color;
        }
    }
}
