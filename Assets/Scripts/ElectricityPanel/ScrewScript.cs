using System;
using DG.Tweening;
using UnityEngine;

public class ScrewScript : MonoBehaviour
{
    public DOTweenAnimation moveAnim;
    public DOTweenAnimation rotateAnim;
    public GameObject parent;
    public Material highligthMaterial;
    private Material baseMaterial;
    private MeshRenderer mesh;
    
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        mesh = GetComponent<MeshRenderer>();
        baseMaterial = mesh.material;
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

    public void OnMouseEnter()
    {
        if (_gameManager.GetPlayerInventory().GetEquippedItem().TypeOfItem == Item.ItemType.Screwdriver)
        {
            mesh.material = highligthMaterial;
        }
    }

    public void OnMouseExit()
    {
        mesh.material = baseMaterial;
    }
}
