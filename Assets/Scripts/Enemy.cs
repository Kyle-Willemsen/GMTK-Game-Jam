using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navAgent;
    HeroMovement heroMovement;

    public float health;
    public float currentSpeed;
    public float baseSpeed;
    public int damage;
    private bool canAttack;
    public float attackReset;

    public GameObject floatingText;
    //public GameObject weaponVariant;

    private void Start()
    {
        player = GameObject.Find("Hero").transform;
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
        heroMovement.AllEnemies.Add(this.gameObject);

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
            heroMovement.AllEnemies.Remove(this.gameObject);
            heroMovement.nearestDistance = 1000;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        var ft = Instantiate(floatingText, transform.position, Quaternion.identity, transform);
        ft.GetComponent<TextMesh>().text = damage.ToString();
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
