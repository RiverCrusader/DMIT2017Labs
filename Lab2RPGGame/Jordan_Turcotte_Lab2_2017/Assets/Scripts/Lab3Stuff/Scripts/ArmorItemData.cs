using UnityEngine;

public class ArmorItemData : InventoryItemData
{
    public int armorRating;
    public EquipSlot equipSlot;

    public ArmorItemData(ArmorItemSO _config)
    {
        this.config = _config;
        this.flavourText = _config.flavourText;
        this.itemName = _config.itemName;
        this.icon = config.icon;
        this.armorRating = _config.armorRating;
        this.equipSlot = _config.equipSlot;
        quantity = 1;
    }
}
