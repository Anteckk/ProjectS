using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UI;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Hand;
    [SerializeField] GameObject crate;
    [SerializeField] GameObject electricPanel;
    [SerializeField] Material redCableMaterial;
    [SerializeField] Material blueCableMaterial;
    private float speed;
    private float rotationSpeed;
    private bool isSherlock;
    private bool isLifting;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    public Material SherlockMaterial;
    public Material WatsonMaterial;
    [SerializeField] Camera camera;
    private Vector2 XZAxis;
    private InventoryWheelController inventoryWheelController;
    private Interactable interactedObject;
    private List<GameObject> redObjects;
    private Transform previousSpawnPoint = null;
    private Transform spawnPoint;
    private GameObject crateTaken;
    private UICharacterChange UICharacterChange;

    private void Awake()
    {
        inventoryWheelController = FindObjectOfType<InventoryWheelController>();
        UICharacterChange = FindObjectOfType<UICharacterChange>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.State == GameState.HUB && GameManager.instance.spawnPointHasBeenSet)
        {
            gameObject.transform.position = GameManager.instance.GetLastHubSpawnPoint();
        }
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        speed = 10;
        rotationSpeed = 10;
        isSherlock = true;
        isLifting = false;

        if (electricPanel != null)
        {
            redObjects = electricPanel.GetComponent<ElectricityPanel>().getRedObjects();
        }

        if (redObjects != null)
        {
            foreach (var redObject in redObjects)
            {
                redObject.GetComponent<MeshRenderer>().material.color = blueCableMaterial.color;
            }
        }

        camera.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate() {
        var transformCam = camera.transform;
        Vector3 movement = transformCam.right * XZAxis.x + transformCam.forward * XZAxis.y;

        Vector3 direction = new Vector3(movement.x, 0f, movement.z);
        rb.velocity = direction * speed + rb.velocity.y * Vector3.up;

        if (XZAxis.magnitude != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }

    public bool isItSherlock()
    {
        return isSherlock;
    }

    public void switchCharacter()
    {
        //Trigger the character coin rotating
        // UICharacterChange.Switch();
        // Check which character we played to change it
        if (crateTaken == null)
        {
            if (isSherlock)
            {
                isSherlock = false;
            }
            else
            {
                isSherlock = true;
            }

            if (isSherlock)
            {
                speed = 10;
                meshRenderer.material = SherlockMaterial;
                if (redObjects != null)
                {
                    foreach (var redObject in redObjects)
                    {

                        redObject.GetComponent<MeshRenderer>().material.color = blueCableMaterial.color;
                    }
                }
            }
            else
            {
                speed = 20;
                meshRenderer.material = WatsonMaterial;
                if (redObjects != null)
                {
                    foreach (var redObject in redObjects)
                    {

                        redObject.GetComponent<MeshRenderer>().material.color = redCableMaterial.color;
                    }
                }
            }
        }
    }

    #region Getter
    public InventoryWheelController getInventoryWheelController()
    {
        return inventoryWheelController;
    }
    #endregion


    void OnMovement(InputValue prmInputValue)
    {
        XZAxis = prmInputValue.Get<Vector2>();
    }

    void OnChangeCharacter(InputValue prmInputValue)
    {
        switchCharacter();
    }

    void OnShowInventory(InputValue prmInputValue)
    {
        inventoryWheelController.ShowInventory();
    }

    void OnInteract()
    {
        interactedObject = GetComponentInChildren<InteractionRangeBehaviour>().getInteractableObject();

        if (interactedObject != null && !isLifting)
        {
            interactedObject.action();
            if (interactedObject.getObjectCamera() != null)
            {
                camera.enabled = false;
                interactedObject.getObjectCamera().enabled = true;
            }
        } else if (isLifting)
        {
            crateTaken.GetComponent<TakeObjet>().action();
        }
    }

    void OnBack()
    {
        if (interactedObject.getObjectCamera() != null && camera.enabled != true)
        {
            interactedObject.getObjectCamera().enabled = false;
            camera.enabled = true;
        }
    }

    public void TakeCrate()
    {
        isLifting = true;
        crateTaken = Instantiate(crate, Hand.transform);
        crateTaken.GetComponent<Rigidbody>().useGravity = false;
        crateTaken.GetComponent<Rigidbody>().isKinematic = true;
        crateTaken.GetComponent<TakeObjet>().isTaken();
        crateTaken.GetComponent<BoxCollider>().isTrigger = true;
    }

    public void releaseCrate()
    {
        isLifting = false;
        crateTaken.GetComponent<BoxCollider>().isTrigger = false;
        crateTaken.GetComponent<Rigidbody>().useGravity = true;
        crateTaken.GetComponent<Rigidbody>().isKinematic = false;
    }

}