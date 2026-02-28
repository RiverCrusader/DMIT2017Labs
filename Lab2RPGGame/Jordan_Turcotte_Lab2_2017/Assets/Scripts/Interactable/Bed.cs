using UnityEngine;
using UnityEngine.Events;

public class Bed : MonoBehaviour, IInteractableObject
{
    public UnityEvent OnSleep;
    private Heal heal;

    void Awake()
    {
        heal = GameObject.FindGameObjectWithTag("Heal").GetComponent<Heal>();
        OnSleep.AddListener(HealPlayer);
    }

    public void Interact()
    {
        OnSleep?.Invoke();
    }

    public void HealPlayer()
    {
        heal.HealPlayer();
    }
}
