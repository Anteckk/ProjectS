using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class CameraBehaviour : MonoBehaviour
{
    public CinemachineVirtualCamera camera;

    public CinemachineOrbitalTransposer cinemachineOrbitalTransposer;

    // Start is called before the first frame update
    void Start()
    {
        cinemachineOrbitalTransposer = camera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cinemachineOrbitalTransposer.m_XAxis.m_MaxSpeed = 600;
        }

        if (Input.GetMouseButtonUp(0))
        {
            cinemachineOrbitalTransposer.m_XAxis.m_MaxSpeed = 0;
        }
    }
}