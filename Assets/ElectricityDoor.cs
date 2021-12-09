using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ElectricityDoor : MonoBehaviour
{
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
        anim.DOPlay();
        enabled = false;
    }
}
