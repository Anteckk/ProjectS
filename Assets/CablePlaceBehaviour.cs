using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablePlaceBehaviour : MonoBehaviour
{

    private bool isOccuped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void occupe()
    {
        isOccuped = true;
    }

    public void free()
    {
        isOccuped = false;
    }

    public bool haveCable()
    {
        return isOccuped;
    }
}
