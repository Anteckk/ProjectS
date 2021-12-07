using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryWheelButtonController : MonoBehaviour
{
    public int iD;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    public Sprite icon;
    
    private Animator anim;
    private bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }

    public void Selected()
    {
        selected = true;
        InventoryWheelController.itemID = iD;
    }
    
    public void Deselected()
    {
        selected = false;
        InventoryWheelController.itemID = -1;
    }

    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
        itemText.text = itemName;
    }
    
    public void HoverExit()
    {
        anim.SetBool("Hover", false);
        itemText.text = "";
    }
}
