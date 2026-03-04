using UnityEngine;

[CreateAssetMenu(fileName = "ArmorItemSO", menuName = "Inventory System/ArmorItemSO")]
public class ArmorItemSO : InventoryDataSO
{
    public int armorRating;
    public EquipSlot equipSlot;

    public override InventoryItemData CreateRuntimeData()
    {
        return new ArmorItemData(this);
    }
}

public enum EquipSlot
{
    HEAD,
    CHEST,
    ARMS,
    LEGS,
    WEAPON
}
