using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Lever : MonoBehaviour
{
    
    [SerializeField] List<GameObject> wireList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("lever clic : " + checkWires());
    }
    
    
    public bool checkWires()
    {
        bool result = true;

        foreach (var wire in wireList)
        {
            result = result && wire.GetComponentInParent<WireBehaviour>().idGoodPlaced();
        }

        return result;
    }
}