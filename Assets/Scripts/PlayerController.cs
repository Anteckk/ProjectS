using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed;
    private bool isSherlock;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    public Material SherlockMaterial;
    public Material WatsonMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        speed = 50;
        isSherlock = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);

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
            speed = 50;
            meshRenderer.material = SherlockMaterial;
        }
        else
        {
            speed = 80;
            meshRenderer.material = WatsonMaterial;
        }
    }
}
