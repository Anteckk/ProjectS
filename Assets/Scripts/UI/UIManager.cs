using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    [SerializeField] public InventoryWheelController wheelController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {

    }
}
