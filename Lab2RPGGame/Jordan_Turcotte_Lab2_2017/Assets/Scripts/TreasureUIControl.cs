using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class TreasureUIControl : MonoBehaviour
{
    public int treasureCount;

    public TMP_Text goldAmount;

    private Chest chest;

    void Awake()
    {
        chest = GameObject.FindGameObjectWithTag("TreasureChest").GetComponent<Chest>();

        if(chest != null) chest.OnChestOpen += IncreaseTreasureAmount;
        
    }
    public void IncreaseTreasureAmount()
    {
        treasureCount++;
        goldAmount.text = $"{treasureCount}";
    }
}
