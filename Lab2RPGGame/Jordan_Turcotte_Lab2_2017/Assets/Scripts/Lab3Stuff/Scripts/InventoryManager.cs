using System.Collections.Generic;
using System;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryDataSO, InventoryItemData> inventory = new Dictionary<InventoryDataSO, InventoryItemData>();

    public InventoryDataSO[] tmp;
    public event Action<Dictionary<InventoryDataSO, InventoryItemData>> onInventoryUpdate;

    private void OnEnable()
    {
       foreach(InventoryDataSO item in tmp)
        {
            AddItem(item);
        }
    }

    public void AddItem(InventoryDataSO _itemToAdd)
    {
        if(!inventory.TryAdd(_itemToAdd, _itemToAdd.CreateRuntimeData()))
        {
            inventory[_itemToAdd].quantity++;
        }
        onInventoryUpdate?.Invoke(inventory);
    }

    public void RemoveItem(InventoryDataSO _itemToRemove)
    {
        if(inventory.TryGetValue(_itemToRemove, out InventoryItemData data))
        {
            if (inventory[_itemToRemove].quantity > 1)
            {
                inventory[_itemToRemove].quantity--;

            }
            else inventory.Remove(_itemToRemove);
        }
        onInventoryUpdate?.Invoke(inventory);
    }
}
