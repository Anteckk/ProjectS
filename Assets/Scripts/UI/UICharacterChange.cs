using UnityEngine;
using UnityEngine.UI;

public class UICharacterChange : MonoBehaviour
{
    public Animator anim;
    public Image icon;
    
    private PlayerController playerController;
    private Sprite sherlockIcon;
    private Sprite watsonIcon;
    private Sprite emptyIcon;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        sherlockIcon = Resources.Load<Sprite>("CharacterChange/Sherlock");
        watsonIcon = Resources.Load<Sprite>("CharacterChange/Watson");
        emptyIcon = Resources.Load<Sprite>("Inventory/Empty");
        icon.sprite = sherlockIcon;
    }
    // Update is called once per frame
    void Update()
    {
        //Trigger the Anim necessary to switch between the two side of the coin when the current character is changed
        anim.SetBool("isSherlock",playerController.getCharacter());
    }

    /// <summary>
    /// Set the icon on the coin to be Sherlock's
    /// </summary>
    public void SetIconToSherlock()
    {
        icon.sprite = sherlockIcon;
    }
    /// <summary>
    /// Set the icon on the coin to be Watson's
    /// </summary>
    public void SetIconToWatson()
    {
        icon.sprite = watsonIcon;
    }
    /// <summary>
    /// Set the icon on the coin to be empty // Used in transition
    /// </summary>
    public void SetIconToEmpty()
    {
        icon.sprite = emptyIcon;
    }
    
}
