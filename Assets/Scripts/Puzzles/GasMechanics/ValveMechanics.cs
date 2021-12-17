using UnityEngine;

public class ValveMechanics : Interactable
{
    [SerializeField] private GameObject GasCloud;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public override void action()
    {
        gasControl();
    }

    public void gasControl()
    {
        if (GasCloud.active)
        {
            GasCloud.SetActive(false);
            Debug.Log("Gas off");
        }
        else
        {
            GasCloud.SetActive(true);
            Debug.Log("Gas on");
        }
    }
}