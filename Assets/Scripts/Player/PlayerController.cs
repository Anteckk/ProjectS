using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject Hand;
    [SerializeField] GameObject crate;
    [SerializeField] GameObject switchPanel;
    [SerializeField] Material redCableMaterial;
    [SerializeField] Material blueCableMaterial;
    [SerializeField] GameObject pauseMenu;
    private float speed;
    private float rotationSpeed;
    private bool isSherlock;
    private bool isLifting;
    public Rigidbody Rigidbody;
    public SkinnedMeshRenderer meshRenderer;
    public Material SherlockMaterial;
    public Material WatsonMaterial;
    public Animator Animator;
    [SerializeField] Camera camera;
    private Vector2 XZAxis;
    private Interactable interactedObject;
    private List<GameObject> redObjects;
    private Transform previousSpawnPoint = null;
    private Transform spawnPoint;
    private Interactable crateTaken;
    private UICharacterChange UICharacterChange;
    private PressurePlateBehaviour[] plates;
    private Vector3 movement;
    public NavMeshAgent agent;
    [SerializeField] CameraBehaviour camBrain;
    [SerializeField] DialogueTrigger contextDialogue;
    


    private void Awake()
    {
        Debug.Log("Player Awake");
        UICharacterChange = FindObjectOfType<UICharacterChange>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.State == GameState.HUB && GameManager.instance.spawnPointHasBeenSet)
        {
            gameObject.transform.position = GameManager.instance.GetLastHubSpawnPoint();
        }
        if (GameManager.instance.State == GameState.HUB && !GameManager.instance.spawnPointHasBeenSet)
        {
            contextDialogue.TriggerDialogue();
        }
        agent.speed = 10;
        rotationSpeed = 10;
        isSherlock = true;
        isLifting = false;

        plates = FindObjectsOfType<PressurePlateBehaviour>();


        if (switchPanel != null)
        {
            redObjects = switchPanel.GetComponent<ElectricityPanel>().GetRedObjects();
        }

        if (redObjects != null)
        {
            foreach (var redObject in redObjects)
            {
                redObject.GetComponent<MeshRenderer>().material.color = blueCableMaterial.color;
            }
        }
        
        InvokeTransparencyWallFromCamera();

        camera.enabled = true;
        
        UIManager.instance.wheelController.RefreshUIItem();
    }

    // Update is called once per frame
    void Update()
    {

       // rb.velocity = direction * speed + rb.velocity.y * Vector3.up;
        var transformCam = camera.transform;
        Vector3 movementCam = transformCam.right * XZAxis.x + transformCam.forward * XZAxis.y;

        Vector3 direction = new Vector3(movementCam.x, 0f, movementCam.z);
         
        movement.Set(direction.x, 0f, direction.z);
        //agent.Move(movement * (Time.deltaTime * agent.speed));
        //agent.SetDestination(transform.position + movement);
        if (XZAxis.magnitude == 0)
        {
            agent.velocity = Vector3.zero;
            Rigidbody.velocity = Vector3.zero;
        }
        else
        {
            agent.velocity = movement * agent.speed;
        }
        
        if (XZAxis.magnitude != 0)
        {
            
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
        
        Animator.SetFloat("Movement", XZAxis.magnitude);
    }
    public bool isItSherlock()
    {
        return isSherlock;
    }

    public void switchCharacter()
    {
        if (Time.timeScale > 0)
        {
            if (!isLifting && !UICharacterChange.isTurning)
            {
                //Trigger the character coin rotating
                UICharacterChange.Switch();
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
                
                    agent.speed = 10;
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
                    agent.speed = 15;
                    meshRenderer.material = WatsonMaterial;
                    if (redObjects != null)
                    {
                        foreach (var redObject in redObjects)
                        {
                            redObject.GetComponent<MeshRenderer>().material.color = redCableMaterial.color;
                        }
                    }
                }
            
                foreach (PressurePlateBehaviour plate in plates)
                {
                    plate.togglePlates(isSherlock);
                }
            }
        }
    }

    #region Getter

    public InventoryWheelController getInventoryWheelController()
    {
        return UIManager.instance.wheelController;
    }

    #endregion


    void OnMovement(InputValue prmInputValue)
    {
        XZAxis = prmInputValue.Get<Vector2>();
        
        
        if (XZAxis.magnitude != 0)
        {
            InvokeRepeating(nameof(InvokeTransparencyWallFromCamera), 0f,0.1f);
        }
        else
        {
            CancelInvoke();
        }
        
    }

    void InvokeTransparencyWallFromCamera()
    {
        camBrain.WallTransparency();
    }

    void OnChangeCharacter(InputValue prmInputValue)
    {
        switchCharacter();
    }

    void OnShowInventory()
    {
        UIManager.instance.wheelController.ToggleInventory();
    }

    void OnHideInventory()
    {
        UIManager.instance.wheelController.ToggleInventory();
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
        }
        else if (isLifting)
        {
            crateTaken.GetComponent<TakeObjet>().action();
        }
    }

    public void OnBack()
    {
        if (interactedObject != null)
        {
            if (interactedObject.getObjectCamera() != null && camera.enabled != true)
            {
                interactedObject.getObjectCamera().enabled = false;
                camera.enabled = true;
            }
        }
    }

    void OnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void TakeCrate()
    {
        Animator.SetBool("Carry", true);
        isLifting = true;
        crateTaken = interactedObject = GetComponentInChildren<InteractionRangeBehaviour>().getInteractableObject();

        crateTaken.GetComponent<Rigidbody>().useGravity = false;
        crateTaken.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezeAll);
        crateTaken.GetComponent<TakeObjet>().isTaken();
    }

    public void ReleaseCrate()
    {
        isLifting = false;
        Animator.SetBool("Carry", false);
        crateTaken.GetComponent<Rigidbody>().useGravity = true;
        crateTaken.GetComponent<Rigidbody>().isKinematic = false;
        crateTaken.GetComponent<Rigidbody>().constraints=(RigidbodyConstraints.None);
    }

    public void RemoveFromPlate(GameObject prmGameObject)
    {
        foreach (var plate in plates)
        {
            plate.objectsList.Remove(prmGameObject);
            plate.ChangePlateState();
            plate.CheckPlates();
        }
    }

    public Vector3 Center()
    {
        return transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
    }
}