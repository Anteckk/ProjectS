using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    public DoorControler Door;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Door.getIsActive() && other.GetComponent("PlayerController"))
        {
            if (Door.getLevelBuildIndex() > 1)
            {
                GameManager.instance.UpdateGameState(GameState.LEVEL);
            }
            else
            {
                GameManager.instance.UpdateGameState(GameState.HUB);
            }
            SceneManager.LoadScene(Door.getLevelBuildIndex());
        }
    }
}
