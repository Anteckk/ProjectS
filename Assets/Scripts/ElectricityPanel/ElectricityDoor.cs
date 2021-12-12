using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine.InputSystem;

public class ElectricityDoor : MonoBehaviour
{
    [SerializeField] GameObject parent;
    public DOTweenAnimation anim;
    private int screwUnscrewed = 0;
    public void CountScrews()
    {
        screwUnscrewed++;
        if (screwUnscrewed == 4)
        {
            Disappear();
        }
    }

    public void Disappear()
    {
        parent.GetComponent<ElectricityPanel>().OpenDoor();
        anim.DOPlay();
        enabled = false;
    }
}
