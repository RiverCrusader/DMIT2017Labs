using UnityEngine;
using UnityEngine.Events;

public class Treasure : MonoBehaviour, IInteractableObject
{
    public UnityEvent OnInteract;
    private Chest chest;
    public bool hasBeenOpened = false;
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
        if(!hasBeenOpened) chest.OpenChest();
        hasBeenOpened = true;
    }
}
