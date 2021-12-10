using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
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
        
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Character movement
        Vector3 movement = transform.right * x + transform.forward * z;
        transform.position += movement.normalized * speed * Time.deltaTime;
        
        camera.transform.LookAt(gameObject.transform);
        
        if (Input.GetKeyDown("r"))
        {
            switchCharacter();
        }
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
    
}
