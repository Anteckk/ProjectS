using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject dialogueBox;
    public CanvasGroup UICanvas;

    private Queue<Dialogue.DialogueStruct> dialogueStructQueue = new Queue<Dialogue.DialogueStruct>();
    private Dialogue.DialogueStruct dialogueStruct;
    private Inventory.Inventory _playerInventory;
    private int NumberInArray;

    public GameState State;
    public bool spawnPointHasBeenSet = false;
    public bool statuetteIsPickedUp = false;
    private Vector3 currentRoomCheckPoint;
    private DialogueBox DialogueText;
    [SerializeField] Vector3 lastHubSpawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitInventory();
        if (State == GameState.MAINMENU)
        {
            UICanvas.alpha = 0;
            UICanvas.blocksRaycasts = false;
            UICanvas.interactable = false;
        }

        DialogueText = dialogueBox.GetComponent<DialogueBox>();
    }


    /// <summary>
    /// Change the state to a new one
    /// </summary>
    /// <param name="newState">the new state to give the GameManager</param>
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        GameStateChange(newState);
    }

    private void GameStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.MAINMENU:
                UICanvas.alpha = 0;
                UICanvas.blocksRaycasts = false;
                UICanvas.interactable = false;
                UIManager.instance.wheelController.inventoryWheelSelected = false;
                break;
            case GameState.HUB:
                UICanvas.alpha = 1;
                UICanvas.blocksRaycasts = true;
                UICanvas.interactable = true;
                UIManager.instance.wheelController.inventoryWheelSelected = false;
                break;
            case GameState.LEVEL:
                UICanvas.alpha = 1;
                UICanvas.blocksRaycasts = true;
                UICanvas.interactable = true;
                if (GetPlayerInventory().GetInventorySize() >= 2)
                {
                    GetPlayerInventory().RemoveAllItemOfType(Item.ItemType.Statue);
                    UIManager.instance.wheelController.RefreshUIItem();
                }

                UIManager.instance.wheelController.inventoryWheelSelected = false;
                break;
        }
    }

    /// <summary>
    /// Initialise player inventory
    /// </summary>
    private void InitInventory()
    {
        _playerInventory = new Inventory.Inventory();
        _playerInventory.AddItem(new Item(Item.ItemType.Screwdriver, false));
    }

    /// <summary>
    /// Set the player lastHubSpawnPoint if he is currently in the hub
    /// Not implemented -> If player "dies" set his lastHubSpawnPoint to the bed;
    /// </summary>
    /// <param name="pos">The transform of the gameobject</param>
    public void SetSpawnPoint(Transform pos)
    {
        if (State == GameState.HUB)
        {
            if (!spawnPointHasBeenSet)
            {
                spawnPointHasBeenSet = true;
            }

            lastHubSpawnPoint = pos.transform.position;
        }
    }


    /// <summary>
    /// Return player's inventory
    /// </summary>
    /// <returns>An Inventory</returns>
    public Inventory.Inventory GetPlayerInventory()
    {
        return _playerInventory;
    }

    /// <summary>
    /// Return the last spawn point the player walked on in the hub
    /// </summary>
    /// <returns>The position of the spawn point</returns>
    public Vector3 GetLastHubSpawnPoint()
    {
        return lastHubSpawnPoint;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        Debug.Log("DialogueBox.isActive : " + dialogueBox.activeSelf);
        dialogueStructQueue.Clear();
        foreach (Dialogue.DialogueStruct dialogueStructure in dialogue.dialogueStruct)
        {
            dialogueStructQueue.Enqueue(dialogueStructure);
        }
        SetupDialogue();
    }

    public void SetupDialogue()
    {
        if (dialogueStructQueue.Count != 0)
        {
            dialogueStruct = dialogueStructQueue.Dequeue();
            NumberInArray = 0;
            NextSentenceDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    public void NextSentenceDialogue()
    {
        if (dialogueStruct.texts.Length > NumberInArray)
        {
            StopAllCoroutines();
            TypeName(dialogueStruct.name);
            StartCoroutine(TypeSentence(dialogueStruct.texts[NumberInArray]));
            NumberInArray++;
        }
        else
        {
            SetupDialogue();
        }
    }
    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Time.timeScale = 1;
    }

    public void TypeName(string name)
    {
        dialogueBox.GetComponent<DialogueBox>().nameText.text = name;
    }
    IEnumerator TypeSentence(string sentence)
    {
        Time.timeScale = 0;
        DialogueText.dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}

/// <summary>
/// Game current state
/// </summary>
public enum GameState
{
    MAINMENU,
    HUB,
    LEVEL,
}