using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                return _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
        }
    }

    private static GameManager _instance;
    private Queue<string> dialogue;
    
    public GameState State;
    public bool spawnPointHasBeenSet = false;
    public bool statuetteIsPickedUp = false;
    private Vector3 currentRoomCheckPoint;
    [SerializeField] Vector3 lastHubSpawnPoint;
    private Inventory.Inventory _playerInventory;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        InitInventory();
    }
    /// <summary>
    /// Change the state to a new one
    /// </summary>
    /// <param name="newState">the new state to give the GameManager</param>
    public void UpdateGameState(GameState newState)
    {
        State = newState;
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
        Debug.Log("Starting dialogue with " + dialogue.name);
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