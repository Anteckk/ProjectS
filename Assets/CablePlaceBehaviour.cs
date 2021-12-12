using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class CablePlaceBehaviour : MonoBehaviour
{

    private bool isOccuped;
    private string cableName;
    // Start is called before the first frame update
    void Start()
    {
        free();
        cableName = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void occupe(string name)
    {
        isOccuped = true;
        cableName = name;
        //Debug.Log(gameObject.name + isOccuped + " occupe by " + cableName);
    }

    public void free()
    {
        isOccuped = false;
        cableName = "";
        //Debug.Log(gameObject.name + isOccuped + " free by " + cableName);
    }

    public bool haveCable()
    {
        return isOccuped;
    }

    public string getCableName()
    {
        return cableName;
    }
}
