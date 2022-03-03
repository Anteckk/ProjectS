using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class CameraBehaviour : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineOrbitalTransposer;
    public Camera camera;

    private CinemachineOrbitalTransposer OrbitalTransposer;

    public PlayerController player;

    [FormerlySerializedAs("WallEmptyGameObject")]
    public GameObject WallGameObject;


    private List<GameObject> _walls = new List<GameObject>();


    RaycastHit hit;


    private void Awake()
    {
        for (int i = 0; i < WallGameObject.transform.childCount; i++)
        {
            _walls.Add(WallGameObject.transform.GetChild(i).gameObject);
        }

        Debug.Log("Added walls to walls array. childCount : " + WallGameObject.transform.childCount
                                                              + ". Walls length : " + _walls.Count);
    }

    // Start is called before the first frame update
    void Start()
    {
        OrbitalTransposer = cinemachineOrbitalTransposer.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        OrbitalTransposer.m_XAxis.m_MaxSpeed = 0;

        player = GetComponentInParent<PlayerController>();
    }


    void OnCameraClick(InputValue prmInputValue)
    {
        if (prmInputValue.isPressed)
        {
            OrbitalTransposer.m_XAxis.m_MaxSpeed = 150;
            InvokeRepeating(nameof(WallTransparency), 0f, 0.1f);
        }
        else
        {
            OrbitalTransposer.m_XAxis.m_MaxSpeed = 0;
            if (IsInvoking())
            {
                CancelInvoke();
            }
        }
    }


    public void WallTransparency()
    {
        var transformCamera = camera.transform;
        if (Physics.SphereCast(transformCamera.position, 1, transformCamera.forward, out hit))
        {
            if (hit.transform.gameObject.CompareTag("WallCenterTrigger"))
                {
                    SetWallState("WallCenter", false);
                }
            else
            {
                SetWallState("WallCenter", true);
            }
        }


        Vector3 Direction = transform.forward;


        if (Direction.x > 0)
        {
            SetWallState("WallNorth", false);
            SetWallState("WallSouth", true);
        }
        else
        {
            SetWallState("WallNorth", true);
            SetWallState("WallSouth", false);
        }

        if (Direction.z > 0)
        {
            SetWallState("WallWest", false);
            SetWallState("WallEast", true);
        }
        else
        {
            SetWallState("WallWest", true);
            SetWallState("WallEast", false);
        }
    }

    public void SetWallState(String prmTag, bool prmState)
    {
        foreach (var wall in _walls)
        {
            if (wall.CompareTag(prmTag))
            {
                wall.SetActive(prmState);
            }
        }
    }
}