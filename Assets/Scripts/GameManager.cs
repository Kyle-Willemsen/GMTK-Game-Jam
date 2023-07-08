using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> enemySpawnPoints = new List<Transform>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> weapons = new List<GameObject>();
    public List<Transform> weaponSpawnPoints = new List<Transform>();

    public float enemySpawnTime;
    private float enemyTimer;

    public float weaponSpawnTime;
    private float weaponTimer;


    private void Start()
    {
        enemyTimer = enemySpawnTime;
    }


    private void Update()
    {
        if (enemyTimer > 0)
        {
            enemyTimer -= Time.deltaTime;
        }
        if (enemyTimer <= 0)
        {
            SpawnEnemy();
        }
        if (weaponTimer > 0)
        {
            weaponTimer -= Time.deltaTime;
        }
        if (weaponTimer <= 0)
        {
            SpawnWeapon();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Count)], enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)].position, Quaternion.identity);
        enemyTimer = enemySpawnTime;
    }

    private void SpawnWeapon()
    {
        Instantiate(weapons[Random.Range(0, weapons.Count)], weaponSpawnPoints[Random.Range(0, weaponSpawnPoints.Count)].position, Quaternion.identity);
        weaponTimer = weaponSpawnTime;
    }

}
