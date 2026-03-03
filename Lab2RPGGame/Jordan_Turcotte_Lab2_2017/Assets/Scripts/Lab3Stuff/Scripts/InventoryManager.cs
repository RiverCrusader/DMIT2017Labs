using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryDataSO, InventoryItemData> inventory = new Dictionary<InventoryDataSO, InventoryItemData>();


    public void AddItem(InventoryDataSO _itemToAdd)
    {
        if(!inventory.TryAdd(_itemToAdd, _itemToAdd.CreateRuntimeData()))
        {
            inventory[_itemToAdd].quantity++;
        }
    }

    public void RemoveItem(InventoryDataSO _itemToRemove)
    {
        // if(inventory.TryGetValue(_itemToRemove, out ))
        // {
            
        // }
        if(inventory[_itemToRemove].quantity > 1)
        {
            inventory[_itemToRemove].quantity--;
            return;
        }
        inventory.Remove(_itemToRemove);
    }
}
