using UnityEngine;

public class WeaponItemData : InventoryItemData
{
    public int weaponStrength;
    public int weaponDurability;

    public WeaponItemData(WeaponItemSO _config)
    {
        this.config = _config;
        this.flavourText = _config.flavourText;
        this.itemName = _config.itemName;
        this.icon = config.icon;
        this.weaponStrength = _config.weaponStrength;
        this.weaponDurability = _config.weaponDurability;
        quantity = 1;
    }
}
