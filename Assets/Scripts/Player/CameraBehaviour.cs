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
    public CinemachineVirtualCamera cinemachineOrbitalTransposer;
    public Camera camera;

    private CinemachineOrbitalTransposer OrbitalTransposer;

    public PlayerController player;

    public Material transparentMaterial;
    public Material originalMaterial;
    
    private GameObject wall;
    
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        OrbitalTransposer = cinemachineOrbitalTransposer.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        OrbitalTransposer.m_XAxis.m_MaxSpeed = 0;

        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCameraClick(InputValue prmInputValue)
    {
        if (prmInputValue.isPressed)
        {
            OrbitalTransposer.m_XAxis.m_MaxSpeed = 150;
            InvokeRepeating(nameof(WallTransparency), 0f, 0.1f );
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
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                
                if (wall != hit.collider.gameObject)
                {
                    if (wall)
                    {
                        wall.GetComponent<MeshRenderer>().material = originalMaterial;
                    }
                    wall = hit.collider.gameObject;
                }
                wall.GetComponent<MeshRenderer>().material = transparentMaterial;
            }
            else
            {
                if (wall)
                {
                    wall.GetComponent<MeshRenderer>().material = originalMaterial;
                }
            }
        }
    }
}