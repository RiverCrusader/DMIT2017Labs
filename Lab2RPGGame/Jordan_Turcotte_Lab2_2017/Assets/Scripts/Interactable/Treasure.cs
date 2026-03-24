using System;
using UnityEngine;
using UnityEngine.Events;

public class Treasure : MonoBehaviour, IInteractableObject
{
    public UnityEvent OnInteract;
    private Chest chest;
    public bool hasBeenOpened = false;
    public event Action<InventoryContainer> onContainerOpen;
    private InventoryContainer container;

    void Awake()
    {
        chest = GameObject.FindGameObjectWithTag("Gold").GetComponent<Chest>();
        container = GetComponent<InventoryContainer>();

        OnInteract.AddListener(OpenChest);
    }

    public void Interact()
    {
        OnInteract?.Invoke();
    }

    public void OpenChest()
    {
        //Can always see the loot but just not get the gold
        onContainerOpen?.Invoke(container);

        if(!hasBeenOpened)
        {
            chest.OpenChest();
            hasBeenOpened = true;
        }
    }
}
