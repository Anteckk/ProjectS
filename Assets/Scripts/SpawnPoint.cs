using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private PlayerController _playerController;
    private bool _onlyOnce = false;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_onlyOnce)
        {
            Debug.Log("Test");
            _playerController.SetSpawnPoint(transform);
            _onlyOnce = true;
        }
    }
}
