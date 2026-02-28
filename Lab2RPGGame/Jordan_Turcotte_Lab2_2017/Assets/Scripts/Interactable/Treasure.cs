using UnityEngine;
using UnityEngine.Events;

public class Treasure : MonoBehaviour, IInteractableObject
{
    public UnityEvent OnInteract;
    private Chest chest;
    void Awake()
    {
        chest = GameObject.FindGameObjectWithTag("Gold").GetComponent<Chest>();
        OnInteract.AddListener(OpenChest);
    }

    public void Interact()
    {
        OnInteract?.Invoke();
    }

    public void OpenChest()
    {
        chest.OpenChest();
    }
}
