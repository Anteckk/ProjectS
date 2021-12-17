using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _onlyOnce = false;

    private void OnTriggerStay(Collider other)
    {
        if (!_onlyOnce)
        {
            GameManager.instance.SetSpawnPoint(gameObject.transform);
            _onlyOnce = true;
        }
    }
}