using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] int levelBuildIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getIsActive()
    {
        return isActive;
    }

    public int getLevelBuildIndex()
    {
        return levelBuildIndex;
    }

    public void SetIsActive(bool boolean)
    {
        isActive = boolean;
    }
}
