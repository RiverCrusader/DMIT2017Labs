using TMPro;
using UnityEngine;

public class TreasureUIControl : MonoBehaviour
{
    public int treasureCount;
    public TMP_Text goldAmount;
    public Chest chest;

    public TMP_Text HP, maxHP;
    public TopDownPlayerMovement player;

    void Awake()
    {
        // chest = GameObject.FindGameObjectWithTag("TreasureChest").GetComponent<Chest>();

        if(chest != null) chest.OnChestOpen += IncreaseTreasureAmount;

        player.OnTakeDamage += AdjustHP;
        maxHP.text = $"/ {player.maxHP} HP";
        
    }
    public void SetUIOnLoad()
    {
        treasureCount = GameStateManager.Instance.gameState.PlayerGold;
        goldAmount.text = $"{treasureCount}";
        HP.text = $"{player.HP}";
    }
    public void IncreaseTreasureAmount()
    {
        treasureCount += 10;
        goldAmount.text = $"{treasureCount}";
    }
    
    public void AdjustHP()
    {
        HP.text = $"{player.HP}";
    }
    public void SaveAndExit()
    {
        GameStateManager.Instance.SaveGameState();
        Application.Quit();
    }
}
