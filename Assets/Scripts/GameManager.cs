using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get { return _instance; }
    }
    public GameState State;
    public bool spawnPointHasBeenSet = false;
    private Vector3 currentRoomCheckPoint;
    private Vector3 lastHubSpawnPoint;
    private Inventory.Inventory _playerInventory;
    private static GameManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate GameManager found");
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitInventory();
    }

    private void Start()
    {
        UpdateGameState(GameState.MAINMENU);
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
