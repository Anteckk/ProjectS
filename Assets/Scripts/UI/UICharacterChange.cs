using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterChange : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField]private Vector3 angleRotation;
    [SerializeField]private float durationRotation;
    public bool isTurning = false;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Switch()
    {
        if (!isTurning)
        {
            transform.DORotate(angleRotation, durationRotation).SetRelative(true)
                .SetLoops(1, LoopType.Incremental).OnStart(() => isTurning = true).OnComplete(() => isTurning = false);
        }
        
    }
}
