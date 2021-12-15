using System;
using DG.Tweening;
using UnityEngine;

public class ScrewScript : MonoBehaviour
{
    public DOTweenAnimation moveAnim;
    public DOTweenAnimation rotateAnim;
    public GameObject parent;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void DestroyThis()
    {
        parent.GetComponent<ElectricityDoor>().CountScrews();
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (_gameManager.GetPlayerInventory().GetEquippedItem().TypeOfItem == Item.ItemType.Screwdriver)
        {
            moveAnim.DOPlay();
            rotateAnim.DOPlay();
        }
    }
}
