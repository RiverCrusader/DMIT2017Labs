using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<EquipSlot, InventoryItemData> equipDictionary = new();
    public static EquipmentManager instance;

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
        if(itemToEquip is ArmorItemData armor)
        {
            equipDictionary[armor.equipSlot] = armor;
            Debug.Log($"{equipDictionary[armor.equipSlot].itemName} was Equipped");
        }
        else if(itemToEquip is WeaponItemData weapon)
        {
            equipDictionary[EquipSlot.WEAPON] = weapon;
            Debug.Log($"{equipDictionary[EquipSlot.WEAPON].itemName} was Equipped");
        }
        onEquip?.Invoke(equipDictionary);
    }
}
