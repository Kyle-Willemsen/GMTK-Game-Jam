using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> enemySpawnPoints = new List<Transform>();
    public List<GameObject> enemies = new List<GameObject>();

    public float spawnTime;
    private float timer;

    private void Start()
    {
        timer = spawnTime;
    }


    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Count)], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)].position, Quaternion.identity);
        timer = spawnTime;
    }

}
