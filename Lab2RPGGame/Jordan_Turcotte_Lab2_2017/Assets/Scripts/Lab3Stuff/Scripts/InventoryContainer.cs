using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
   private Dictionary<InventoryDataSO, InventoryItemData> containerInventory = new();

   public List<InventoryDataSO> sartingInventory = new();
   public InventoryManager playerInventory;

    void Start()
    {
        foreach(InventoryDataSO item in sartingInventory)
        {
            if(!containerInventory.TryAdd(item, item.CreateRuntimeData()))
            {
                containerInventory[item].quantity++;
            }
        }
    }

    public void AddItemToContainer(InventoryDataSO _itemToAdd)
    {
        playerInventory.RemoveItem(_itemToAdd);
        if(!containerInventory.TryAdd(_itemToAdd, _itemToAdd.CreateRuntimeData()))
        {
            containerInventory[_itemToAdd].quantity++;
        }
    }

    public void AddItemToPlayerInventory(InventoryDataSO _itemToRemove)
    {
        if(containerInventory[_itemToRemove].quantity > 1)
        {
            containerInventory[_itemToRemove].quantity--;
            return;
        }
        else containerInventory.Remove(_itemToRemove);

        playerInventory.AddItem(_itemToRemove);
        
    }
}
