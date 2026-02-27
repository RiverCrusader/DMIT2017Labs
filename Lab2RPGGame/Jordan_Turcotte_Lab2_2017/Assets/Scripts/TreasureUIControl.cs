using TMPro;
using UnityEngine;

public class TreasureUIControl : MonoBehaviour
{
    public int treasureCount;
    public TMP_Text goldAmount;
    private Chest chest;

    public TMP_Text HP, maxHP;
    public TopDownPlayerMovement player;

    void Awake()
    {
        chest = GameObject.FindGameObjectWithTag("TreasureChest").GetComponent<Chest>();

        if(chest != null) chest.OnChestOpen += IncreaseTreasureAmount;

        player.OnTakeDamage += AdjustHP;
        maxHP.text = $"/ {player.maxHP} HP";
        
    }
    public void IncreaseTreasureAmount()
    {
        treasureCount++;
        goldAmount.text = $"{treasureCount}";
    }
    
    public void AdjustHP()
    {
        HP.text = $"{player.HP}";
    }
}
