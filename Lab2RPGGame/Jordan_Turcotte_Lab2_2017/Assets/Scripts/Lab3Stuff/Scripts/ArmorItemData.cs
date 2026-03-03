using UnityEngine;

public class ArmorItemData : InventoryItemData
{
    public int armorRating;
    public ArmorType armorType;

    public ArmorItemData(ArmorItemSO _config)
    {
        this.config = _config;
        this.flavourText = _config.flavourText;
        this.itemName = _config.itemName;
        this.icon = config.icon;
        this.armorRating = _config.armorRating;
        this.armorType = _config.armorType;
        quantity = 1;
    }
}
