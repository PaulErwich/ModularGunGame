using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    // Manually enter spawn zones
    private Vector3[] spawnLocations = new[] { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };

    public Enemy enemyPrefab;
    public List<Enemy> aliveEnemies = new List<Enemy>();

    public List<Enemy> SpawnEnemies(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            int random = Random.Range(0, spawnLocations.Length);
            aliveEnemies.Add(Instantiate(enemyPrefab, spawnLocations[random], Quaternion.identity));
        }
        return aliveEnemies;
    }
}
