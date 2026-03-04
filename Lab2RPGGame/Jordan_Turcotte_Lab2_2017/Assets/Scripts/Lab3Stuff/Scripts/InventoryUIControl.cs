using UnityEngine;
using System.Collections.Generic;

public class InventoryUIControl : MonoBehaviour
{
    public InventoryManager targetInventory;
    public GameObject buttonPrefab;
    public Transform contentParent;

    [ContextMenu("Init UI")]
    public void InitUI()
    {
        Dictionary<InventoryDataSO, InventoryItemData> inventoryRef = targetInventory.inventory;

        foreach(InventoryItemData item in inventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, contentParent);
            tmp.GetComponent<InventoryButton>().InitializeButton(item);
        }
    }
}
