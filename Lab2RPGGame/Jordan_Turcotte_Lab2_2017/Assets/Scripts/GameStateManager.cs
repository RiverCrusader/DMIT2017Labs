using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
     public static GameStateManager Instance;
    public List<MapState> mapStates = new List<MapState>();
    public Transform mapParent;
    private EnemySpawner spawner;
    private int currentMapID;
    private MapState currentMapState;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach(MapState mapState in mapStates)
        {
            mapState.InitializeDictionary();
        }
    }
    public void InitializeMap(int mapID_)
    {
       
        foreach (MapState mapState in mapStates)
        {
            if(mapState.mapData.mapID == mapID_)
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

            if(enemy.currentHP > 0) spawner.Spawn(enemy, enemy.currentHP);
        }
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
        
    }
}

[Serializable] 
public class MapState
{
    public GameMap mapData;
    public List<EnemyState> enemyStates;
    public Dictionary<int, EnemyState> enemyDictionary;

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
    public EnemySO enemySO;
}
