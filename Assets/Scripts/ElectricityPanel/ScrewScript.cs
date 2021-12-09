using System;
using DG.Tweening;
using UnityEngine;

public class ScrewScript : MonoBehaviour
{
    public DOTweenAnimation moveAnim;
    public DOTweenAnimation rotateAnim;
    public DOTweenAnimation fallAnim;
    public GameObject parent;

    public void GetHit()
    {
        moveAnim.DOPlay();
        rotateAnim.DOPlay();
    }

    public void Falling()
    {
        fallAnim.DOPlay();
    }

    public void DestroyThis()
    {
        gameObject.SetActive(false);
        parent.GetComponent<ElectricityPanel>().CountScrews();
    }
}
