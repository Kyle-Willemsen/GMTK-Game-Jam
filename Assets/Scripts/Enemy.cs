using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navAgent;

    public float health;
    public float currentSpeed;
    public float baseSpeed;
    public int damage;
    private bool canAttack;
    public float attackReset;

    private void Start()
    {
        player = GameObject.Find("Hero").transform;
        navAgent = gameObject.GetComponent<NavMeshAgent>();

        navAgent.speed = baseSpeed;
        baseSpeed = currentSpeed;
        canAttack = true;
    }

    private void Update()
    {
        navAgent.SetDestination(player.position);

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            if (canAttack)
            {
                canAttack = false;
                other.GetComponent<HeroMovement>().TakeDamage(damage);
                Invoke("AttackReset", attackReset);
            }
        }
    }

    private void AttackReset()
    {
        canAttack = true;
    }
}
