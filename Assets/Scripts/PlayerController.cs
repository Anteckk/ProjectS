using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{

    private float speed;
    private bool isSherlock;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    public Material SherlockMaterial;
    public Material WatsonMaterial;
    private Camera camera;
    private Inventory.Inventory playerInventory;
    private Vector2 XZAxis;

    private void Awake()
    {
        playerInventory = new Inventory.Inventory();
        playerInventory.AddItem(new Item(Item.ItemType.Screwdriver, false));
        playerInventory.AddItem(new Item(Item.ItemType.Statue, true));
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        speed = 10;
        isSherlock = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(XZAxis.x * speed * Time.deltaTime,0,XZAxis.y * speed * Time.deltaTime);
    }

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
        }
        else
        {
            speed = 20;
            meshRenderer.material = WatsonMaterial;
        }
    }

    public Inventory.Inventory getPlayerInventory()
    {
        return playerInventory;
    }

    public bool getCharacter()
    {
        return isSherlock;
    }

    void OnMovement(InputValue prmInputValue)
    {
        XZAxis = prmInputValue.Get<Vector2>();
    }

    void OnChangeCharacter(InputValue prmInputValue)
    {
        switchCharacter();
    }
    
}
