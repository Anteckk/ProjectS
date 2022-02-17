using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Image dialogueBox;
    public CanvasGroup UICanvas;
    public Animator animator;

    private Queue<string> sentences = new Queue<string>();
    private Inventory.Inventory _playerInventory;

    public GameState State;
    public bool spawnPointHasBeenSet = false;
    public bool statuetteIsPickedUp = false;
    private Vector3 currentRoomCheckPoint;
    [SerializeField] Vector3 lastHubSpawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        InitInventory();
        if (State == GameState.MAINMENU)
        {
            UICanvas.alpha = 0;
            UICanvas.blocksRaycasts = false;
            UICanvas.interactable = false;
        }
        //sentences 
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
                break;
            case GameState.HUB:
                UICanvas.alpha = 1;
                UICanvas.blocksRaycasts = true;
                UICanvas.interactable = true;
                break;
            case GameState.LEVEL:
                UICanvas.alpha = 1;
                UICanvas.blocksRaycasts = true;
                UICanvas.interactable = true;
                break;
            default:
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
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting dialogue with " + dialogue.name);
        sentences.Clear();
        dialogueBox.GetComponent<DialogueBox>().nameText.text = dialogue.name + " : ";
        foreach (string text in dialogue.texts)
        {
            sentences.Enqueue(text);
            Debug.Log(text);
        }
        NextSentenceDialogue();
    }

    public void NextSentenceDialogue()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueBox.GetComponent<DialogueBox>().dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBox.GetComponent<DialogueBox>().dialogueText.text += letter;
            yield return null;
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