using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<Enemy> activeEnemies = new List<Enemy>();

    public void Spawn(EnemyState enemyState, int hp)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject tmp = Instantiate(enemyState.enemySO.prefab, spawnPoint.position, Quaternion.identity);

        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = hp;
        activeEnemies.Add(e);
        e.enemyID = enemyState.enemyID;
        e.ATK = enemyState.enemySO.ATK;
        e.DEF = enemyState.enemySO.DEF;
    }
}
