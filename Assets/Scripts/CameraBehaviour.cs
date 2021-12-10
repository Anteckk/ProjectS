using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CameraBehaviour : MonoBehaviour
{
    public CinemachineVirtualCamera camera;

    public CinemachineOrbitalTransposer cinemachineOrbitalTransposer;

    // Start is called before the first frame update
    void Start()
    {
        cinemachineOrbitalTransposer = camera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        cinemachineOrbitalTransposer.m_XAxis.m_MaxSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCameraClick(InputValue prmInputValue)
    {
        if (prmInputValue.isPressed)
        {
            cinemachineOrbitalTransposer.m_XAxis.m_MaxSpeed = 600;
        }
        else
        {
            cinemachineOrbitalTransposer.m_XAxis.m_MaxSpeed = 0;
        }
    }
}