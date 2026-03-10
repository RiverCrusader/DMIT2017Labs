using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<EquipSlot, InventoryItemData> equipDictionary = new();
    public static EquipmentManager instance;
    public InventoryManager inventory;

    public event Action<Dictionary<EquipSlot, InventoryItemData>> onEquip;

    void Awake()
    {
        if(instance == null) instance = this;
        InitilizeEquipment();
    }

    public void InitilizeEquipment()
    {
        equipDictionary.Add(EquipSlot.HEAD, null);
        equipDictionary.Add(EquipSlot.CHEST, null);
        equipDictionary.Add(EquipSlot.ARMS, null);
        equipDictionary.Add(EquipSlot.LEGS, null);
        equipDictionary.Add(EquipSlot.WEAPON, null);

    }

    public void EquipItem(InventoryItemData itemToEquip)
    {
        // equip armor or weapon to corresponding slot
        if(itemToEquip is ArmorItemData armor)
        {
            if (equipDictionary[armor.equipSlot] != null) inventory.AddItem(equipDictionary[armor.equipSlot].config); // if there is already something equipped, remove it and send it back to inventory
            equipDictionary[armor.equipSlot] = armor;
            inventory.RemoveItem(itemToEquip.config); // after equipping remove item from inventory
            Debug.Log(equipDictionary[armor.equipSlot].itemName + " was equipped");
        }
        // same logic but for weapons
        else if (itemToEquip is WeaponItemData weapon) 
        {
            if (equipDictionary[EquipSlot.WEAPON] != null) inventory.AddItem(equipDictionary[EquipSlot.WEAPON].config);

            equipDictionary[EquipSlot.WEAPON] = weapon;
            inventory.RemoveItem(itemToEquip.config);

            Debug.Log(equipDictionary[EquipSlot.WEAPON].itemName + " was equipped");
        }
        onEquip?.Invoke(equipDictionary);// event trigger to update ui etc
    }
}
