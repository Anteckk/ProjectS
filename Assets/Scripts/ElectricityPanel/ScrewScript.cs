using System;
using DG.Tweening;
using UnityEngine;

public class ScrewScript : MonoBehaviour
{
    public DOTweenAnimation moveAnim;
    public DOTweenAnimation rotateAnim;
    public GameObject parent;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void DestroyThis()
    {
        parent.GetComponent<ElectricityDoor>().CountScrews();
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (_playerController.getPlayerInventory().GetEquippedItem().TypeOfItem == Item.ItemType.Screwdriver)
        {
            moveAnim.DOPlay();
            rotateAnim.DOPlay();
        }
    }
}
