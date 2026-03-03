using UnityEngine;

[CreateAssetMenu(fileName = "ArmorItemSO", menuName = "Inventory System/ArmorItemSO")]
public class ArmorItemSO : InventoryDataSO
{
    public int armorRating;
    public ArmorType armorType;

    public override InventoryItemData CreateRuntimeData()
    {
        return new ArmorItemData(this);
    }
}

public enum ArmorType
{
    HEAD,
    CHEST,
    LEGS,
    BOOTS
}
