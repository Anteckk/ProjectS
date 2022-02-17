using UnityEngine;
using DG.Tweening;


public class ElectricityDoor : MonoBehaviour
{
    [SerializeField] GameObject parent;
    public DOTweenAnimation anim;
    private int screwUnscrewed = 0;
    private bool isOpen = false;

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
        isOpen = true;
        enabled = false;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}