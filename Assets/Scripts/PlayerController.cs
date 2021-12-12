using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UI;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using Vector3 = System.Numerics.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject electricPanel;
    [SerializeField] Material redCableMaterial;
    [SerializeField] Material blueCableMaterial;
    private float speed;
    private bool isSherlock;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    public Material SherlockMaterial;
    public Material WatsonMaterial;
    private Camera camera;
    private Inventory.Inventory playerInventory;
    private Vector2 XZAxis;
    private InventoryWheelController inventoryWheelController;
    private Interactable interactedObject;
    private List<GameObject> redObjects;

    private void Awake()
    {
        playerInventory = new Inventory.Inventory();
        playerInventory.AddItem(new Item(Item.ItemType.Screwdriver, false));
        inventoryWheelController = FindObjectOfType<InventoryWheelController>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        speed = 10;
        isSherlock = true;
        
        redObjects = electricPanel.GetComponent<ElectricityPanel>().getRedObjects();
        foreach (var redObject in redObjects)
        {
            redObject.GetComponent<MeshRenderer>().material.color = blueCableMaterial.color;
        }
        
        camera = GetComponentInChildren<Camera>();
        camera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var transformCam = camera.transform;
        UnityEngine.Vector3 movement = transformCam.right * XZAxis.x + transformCam.forward * XZAxis.y;
        
        UnityEngine.Vector3 direction = new UnityEngine.Vector3(movement.x, 0f, movement.z);
        rb.transform.position += direction * speed * Time.deltaTime;

        if (XZAxis.Equals(Vector2.zero))
        {
            var forward = transformCam.forward;
            transform.forward = new UnityEngine.Vector3(forward.x,0f,forward.z);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    // Vector2 rotation(float prmAngle, Vector2 prmVector2)
    // {
    //     var temp = prmVector2.x * Math.Cos(prmAngle) - prmVector2.y * Math.Sin(prmAngle);
    //     var temp2 = prmVector2.x * Math.Sin(prmAngle) + prmVector2.y * Math.Cos(prmAngle);
    //
    //     return new Vector2((float) temp, (float) temp2);
    //
    //     merci charles <3;
    // }

    public void switchCharacter()
    {
        // Check which character we played to change it
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
            foreach (var redObject in redObjects)
            {
                redObject.GetComponent<MeshRenderer>().material.color = blueCableMaterial.color;
            }
        }
        else
        {
            speed = 20;
            meshRenderer.material = WatsonMaterial;
            foreach (var redObject in redObjects)
            {
                redObject.GetComponent<MeshRenderer>().material.color = redCableMaterial.color;
            }
        }
    }

    #region Getter
    public Inventory.Inventory getPlayerInventory()
    {
        return playerInventory;
    }

    public bool getCharacter()
    {
        return isSherlock;
    }

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
        
        if (interactedObject != null)
        {
            interactedObject.action();
            if (interactedObject.getObjectCamera() != null)
            {
                camera.enabled = false;
                interactedObject.getObjectCamera().enabled = true;
            }
            
        }
    }

    void OnBack()
    {
        if (interactedObject.getObjectCamera() != null)
        {
            interactedObject.getObjectCamera().enabled = false;
            camera.enabled = true;
        }
    }
}