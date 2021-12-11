using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ElectricityDoor : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] GameObject parent;
    public DOTweenAnimation anim;
    private int screwUnscrewed = 0;
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
        if (Input.GetMouseButtonDown(0) && !parent.GetComponent<ElectricityPanel>().isDoorOpen())
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
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
        screwUnscrewed++;
        if (screwUnscrewed == 4)
        {
            Disappear();
        }
    }

    public void Disappear()
    {
        parent.GetComponent<ElectricityPanel>().OpenDoor();
        anim.DOPlay();
        enabled = false;
    }
}
