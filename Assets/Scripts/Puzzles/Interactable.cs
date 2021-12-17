using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Camera objectCamera;


    // Start is called before the first frame update
    void Start()
    {
        if (objectCamera != null)
        {
            objectCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void action()
    {
        Debug.Log("Action Interactable");
    }

    public Camera getObjectCamera()
    {
        return objectCamera;
    }
}