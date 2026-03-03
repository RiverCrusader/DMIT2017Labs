using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "Inventory System/InventoryItemSO")]
public abstract class InventoryDataSO : ScriptableObject
{
    public string itemName;
    public string flavourText;
    public Sprite icon;

    public abstract InventoryItemData CreateRuntimeData();
    
}
