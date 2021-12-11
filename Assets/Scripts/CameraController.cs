using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();

    private int currentCameraIndex;
    private GameObject UI;

    private Transform child;
    // Start is called before the first frame update
    void Start()
    {
        currentCameraIndex = 0;
        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }
        cameras[currentCameraIndex].enabled = true;
        UI = GameObject.FindGameObjectWithTag("UI");
    }
    
    
    void OnInteract(InputValue prmInputValue)
    {
        cameras[currentCameraIndex].enabled = false;
        currentCameraIndex = 1;
        cameras[currentCameraIndex].enabled = true;
    }
}
