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

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                Debug.Log("wall");
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
                Debug.Log("Not wall");
                if (wall)
                {
                    wall.GetComponent<MeshRenderer>().material = originalMaterial;
                }
                
            }
        }
        else
        {
            Debug.Log("Not hit");
        }
    }

    void OnCameraClick(InputValue prmInputValue)
    {
        if (prmInputValue.isPressed)
        {
            OrbitalTransposer.m_XAxis.m_MaxSpeed = 150;
        }
        else
        {
            OrbitalTransposer.m_XAxis.m_MaxSpeed = 0;
        }
    }
}