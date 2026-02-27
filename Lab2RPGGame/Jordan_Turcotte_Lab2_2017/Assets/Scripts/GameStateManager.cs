using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    //public List<MapState> mapStates = new List<MapState>();
    public GameState gameState;
    public Transform mapParent;
    private EnemySpawner spawner;
    private int currentMapID;
    private MapState currentMapState;
    public TopDownPlayerMovement player;
    private SaveLoadData saveLoadData;

    private Heal heal;

    private void Awake()
    {
        Instance = this;

        saveLoadData = GetComponent<SaveLoadData>();
        // heal = GameObject.FindGameObjectWithTag("Heal").GetComponent<Heal>();
        // if(heal!= null) heal.OnHeal += ResetEnemies;
        
    }
    private void Start()
    {
        foreach(MapState mapState in gameState.mapStates)
        {
            mapState.InitializeDictionary();
        }
        saveLoadData.LoadData();

        InitializeMap(0);
    }
    public void InitializeMap(int mapID_)
    {
        saveLoadData.SaveData(); // Save previous map data
        saveLoadData.LoadData(); // load all map data and the new stuff
        player.HP = gameState.playerHP;

        foreach (MapState mapState in gameState.mapStates)
        {
            if(mapState.mapID == mapID_)
            {
                currentMapState = mapState;
                BeginEnemySpawn(currentMapState);
                break;
            }
        }
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<EnemySpawner>();
        foreach(EnemyState enemy in map.enemyStates)
        {

            if(enemy.currentHP > 0) spawner.Spawn(enemy.enemyID, enemy.currentHP);
        }
    }

    public void ResetEnemies()
    {
        foreach(MapState mapState in gameState.mapStates)
        {
            foreach(EnemyState e in mapState.enemyStates)
            {
                e.currentHP = e.maxHP;
            }
        }
        saveLoadData.SaveData();
    }

    [ContextMenu("Try Save")]
    public void SaveGameState()
    {
        if (spawner != null)
        {
            List<Enemy> enemies = spawner.activeEnemies;
            foreach (Enemy enemy in enemies)
            {
                currentMapState.enemyDictionary[enemy.enemyID].currentHP = enemy.HP;
                Debug.Log(currentMapState.enemyDictionary[enemy.enemyID].currentHP);
            
            }
        }
        
        gameState.playerHP = player.HP;

        saveLoadData.SaveData();
    }

    // [ContextMenu("Try Load")]
    // public void LoadGameState()
    // {
    //     if (spawner != null)
    //     {
    //         List<Enemy> enemies = spawner.activeEnemies;
    //         foreach (Enemy enemy in enemies)
    //         {
    //             enemy.HP = currentMapState.enemyDictionary[enemy.enemyID].currentHP;
    //         }
    //     }
    //     player.HP = gameState.playerHP;
    // }
}

[Serializable] 
public class MapState
{
    public int mapID;
    public List<EnemyState> enemyStates;
    [NonSerialized] public Dictionary<int, EnemyState> enemyDictionary; 

    public void InitializeDictionary()
    {
        enemyDictionary = new Dictionary<int, EnemyState>();
        foreach(EnemyState enemy in enemyStates)
        {
            enemyDictionary.Add(enemy.enemyID, enemy);
        }
    }
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public int currentHP;
    public int maxHP;
    //public EnemySO enemySO;
}

[Serializable]
public class GameState
{
    public int playerHP;
    public List<MapState> mapStates;
}
