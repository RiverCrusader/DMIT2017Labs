using UnityEngine;
using System.Collections.Generic;

public class InventoryUIControl : MonoBehaviour
{
    public InventoryManager targetInventory;
    public GameObject buttonPrefab;
    public Transform contentParent;
    private List<GameObject> uiButtons = new();

    private void Start()
    {
        InitUI();
        targetInventory.onInventoryUpdate += UpdateUI;
    }
    [ContextMenu("Init UI")]
    public void InitUI()
    {
        Dictionary<InventoryDataSO, InventoryItemData> inventoryRef = targetInventory.inventory;

        foreach(InventoryItemData item in inventoryRef.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, contentParent);
            tmp.GetComponent<InventoryButton>().InitializeButton(item);
            uiButtons.Add(tmp);
        }
    }

    public void UpdateUI(Dictionary<InventoryDataSO, InventoryItemData> inventory_)
    {
        foreach(GameObject go in uiButtons)
        {
            Destroy(go);
        }
        uiButtons.Clear();

        foreach (InventoryItemData item in inventory_.Values)
        {
            GameObject tmp = Instantiate(buttonPrefab, contentParent);
            tmp.GetComponent<InventoryButton>().InitializeButton(item);
            uiButtons.Add(tmp);
        }
    }
}
