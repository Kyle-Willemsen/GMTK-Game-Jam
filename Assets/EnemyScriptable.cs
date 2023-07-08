using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy")]
public class EnemyScriptable : ScriptableObject
{
    public GameObject enemyPrefab;
    public float enemyHealth;
    public float enemyBaseSpeed;
    public float enemyCurrentSpeed;


}
