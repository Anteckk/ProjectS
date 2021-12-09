using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityPanel : MonoBehaviour
{
    public Camera camera;
    public GameObject[] screws;
    private RaycastHit hit;
    private int layerMask;
    private Ray ray;
    private int screwsUnscrewed = 0;

    private void Start()
    {
        layerMask = 1 << 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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

    public void CountScrews()
    {
        screwsUnscrewed++;
        if (screwsUnscrewed == 4)
        {
            Disappear();
        }
    }

    public void Disappear()
    {
        Debug.Log("TBA");
    }
}
