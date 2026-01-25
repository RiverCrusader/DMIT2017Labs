using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.EndRace();
        }
    }
}
