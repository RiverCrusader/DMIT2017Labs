using System.Collections.Generic;
using System;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public Dictionary<InventoryDataSO, InventoryItemData> containerInventory = new();
    public List<InventoryDataSO> startingInventory = new();
    public InventoryManager playerInventoryManager;
    public event Action<InventoryContainer> onContainerUpdated;
    public event Action<InventoryContainer> onInventoryUpdate;
    
   
    private void Start()
    {
        foreach(InventoryDataSO item in startingInventory)
        {
            if (!containerInventory.TryAdd(item, item.CreateRuntimeData()))
            {
                containerInventory[item].quantity++;
            }
        }
    }

    public void AddItemToContainer(InventoryDataSO itemToAdd_) // call this when you pick up an item
    {
        playerInventoryManager.RemoveItem(itemToAdd_);
        if (!containerInventory.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData()))
        {
            containerInventory[itemToAdd_].quantity++;

        }

        onContainerUpdated?.Invoke(this);
        
        //onInventoryUpdate?.Invoke(inventory);
    }

    public void AddItemToPlayerInventory(InventoryDataSO itemToAdd_) // call this when you lose an item
    {
        if (containerInventory.TryGetValue(itemToAdd_, out InventoryItemData data))
        {
            if (containerInventory[itemToAdd_].quantity > 1)
            {
                containerInventory[itemToAdd_].quantity--;
            }
            else containerInventory.Remove(itemToAdd_);
        }
        playerInventoryManager.AddItem(itemToAdd_);
        onContainerUpdated?.Invoke(this);

        //onInventoryUpdate?.Invoke(inventory);


    }
}
