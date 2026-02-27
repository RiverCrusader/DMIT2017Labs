using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<Enemy> activeEnemies = new List<Enemy>();
    public EnemyDatabase enemyDatabase;

    public void Spawn(int enemyID, int hp)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        EnemySO enemySO = enemyDatabase.Get(enemyID);

        GameObject tmp = Instantiate(enemySO.prefab, spawnPoint.position, Quaternion.identity);

        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = hp;
        activeEnemies.Add(e);
        e.enemyID = enemyID;
        e.ATK = enemySO.ATK;
        e.DEF = enemySO.DEF;
    }

    public void ClearEnemies()
    {
        foreach(Enemy enemy in activeEnemies)
        {
            Destroy(enemy.gameObject);
        }
        activeEnemies.Clear();
    }
}
