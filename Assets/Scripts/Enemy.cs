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
    AudioManager audioManager;

    //private Vector3 forceMode;
    //public float force;
   // public float upwardForce;


    //public float knockbackForce;
    //public float knockbackTime;
    //private float knockbackCounter;

    //public GameObject weaponVariant;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
       // if (knockbackCounter <= 0)
       // {
       //     
       // }
       // else
       // {
       //     knockbackCounter -= Time.deltaTime;
       // }

        if (health <= 0)
        {
            Destroy(gameObject);
            heroMovement.AllEnemies.Remove(this.gameObject);
            heroMovement.nearestDistance = 1000;
        }

    }

    public void TakeDamage(float damage)//, Vector3 direction)
    {
        audioManager.Play("HitMarker");
        health -= damage;
        var ft = Instantiate(floatingText, transform.position, Quaternion.identity, transform);
        ft.GetComponent<TextMesh>().text = damage.ToString();

        //Knockback(direction);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            if (canAttack)
            {
                //forceMode = -other.transform.forward * force + other.transform.up * upwardForce;

                Vector3 hitDireciton = other.transform.position - transform.position;
                hitDireciton = hitDireciton.normalized;

                canAttack = false;
                other.GetComponent<HeroMovement>().TakeDamage(damage);//, hitDireciton);
                //other.GetComponent<Rigidbody>().AddForce(forceMode, ForceMode.Impulse);
                Invoke("AttackReset", attackReset);
            }
        }
    }

    //private void Knockback(Vector3 direction)
    //{
    //    Debug.Log("Knockem");
    //    knockbackCounter = knockbackTime;
    //
    //    transform.forward = direction * knockbackForce;
    //}

    private void AttackReset()
    {
        canAttack = true;
    }
}
