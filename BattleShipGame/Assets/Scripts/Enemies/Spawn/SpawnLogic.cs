using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLogic : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public GameObject player;

    int randSpawnP, randEnemies;
    float spawnTime;

    void Start()
    {
        spawnTime = GameMode.spawnRate;
        InvokeRepeating("SpawnAnEnemy", 0f, spawnTime);
    }

    void SpawnAnEnemy()
    {
        if (player != null)
        {
            randSpawnP = Random.Range(0, spawnPoints.Length);
            randEnemies = Random.Range(0, enemies.Length);
            Instantiate(enemies[randEnemies], spawnPoints[randSpawnP].position, Quaternion.identity);
        }
    }
}
