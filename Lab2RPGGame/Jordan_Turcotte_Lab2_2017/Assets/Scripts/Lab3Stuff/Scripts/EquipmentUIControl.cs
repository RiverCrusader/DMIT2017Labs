using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIControl : MonoBehaviour
{
  public List<EquipmentUISlot> equipUISlots = new();

  public Dictionary<EquipSlot, Image> equipmentUIDictionary = new();

    void Start()
    {
        foreach(var slot in equipUISlots)
        {
            equipmentUIDictionary.Add(slot.equipType, slot.UIImage);
        }

        EquipmentManager.instance.onEquip += UpdateUI;

    }
    public void UpdateUI(Dictionary<EquipSlot, InventoryItemData> equipment)
    {
        foreach(EquipSlot equipmentSlot in equipment.Keys)
        {
            if(equipment[equipmentSlot] != null)
            {
                equipmentUIDictionary[equipmentSlot].sprite = equipment[equipmentSlot].icon;
                Color tmp = equipmentUIDictionary[equipmentSlot].color;
                tmp.a = 1;
                equipmentUIDictionary[equipmentSlot].color = tmp;

            }
        }
        
    }
}

[Serializable]
public class EquipmentUISlot
{
    public EquipSlot equipType;
    public Image UIImage;
}
