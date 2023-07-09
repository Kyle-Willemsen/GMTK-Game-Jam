using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class HeroMovement : MonoBehaviour
{
    public Healthbar healthbar;
    private NavMeshAgent navAgent;
    public LayerMask ground;
    private Vector3 walkPoint;
    
    public float playerSpeed;
    public int maxHealth;
    public int currentHealth;

    public float walkPointRange;
    bool walkPointSet;
    public bool enemyInSightRange;
    public float sightRange;
    public LayerMask whatIsEnemy;


    public float pistolRange;
    public float shotgunRange;
    public float machinegunRange;

    public bool isPistol;
    public bool isShotgun;
    public bool isMachinegun;

    public List<GameObject> AllEnemies = new List<GameObject>();
    public GameObject NearestEnemy;
    float distance;
    public float nearestDistance = 1000;

    public TextMeshProUGUI tmpro;
    public float ammoCounter;

    public bool hasWeapon;
    AudioManager audioManager;

    public GameObject arm1;
    public GameObject arm2;


   // public float knockbackForce;
   // public float knockbackTime;
   // private float knockbackCounter;

    private void Start()
    {
        currentHealth = maxHealth;

        audioManager = FindObjectOfType<AudioManager>();
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        navAgent.speed = playerSpeed;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        tmpro.text = ammoCounter + "";

        if (ammoCounter <= 0)
        {
            hasWeapon = false;
            arm1.SetActive(true);
            arm2.SetActive(true);
        }
        else
        {
            hasWeapon = true;
            arm1.SetActive(false);
            arm2.SetActive(false);
        }

        if (!hasWeapon)
        {
            isPistol = false;
            isMachinegun = false;
            isShotgun = false;
        }

        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);

        if (!enemyInSightRange)
        {
            Patrolling();
        }
        else
        {
            Retreat();
        }

        if (isPistol)
        {
            sightRange = pistolRange;
            //tmpro.text = GetComponentInChildren<Pistol>().lifeSpan + "";
            //ammoCounter = GetComponentInChildren<Pistol>().lifeSpan;
            //ammoCounter = 6;
            isShotgun = false;
            isMachinegun = false;
            hasWeapon = true;
        }

        if (isShotgun)
        {
            sightRange = shotgunRange;
            //tmpro.text = GetComponentInChildren<Shotgun>().lifeSpan + "";
            //ammoCounter = GetComponentInChildren<Shotgun>().lifeSpan;
            //ammoCounter = 9;
            isPistol = false;
            isMachinegun = false;
            hasWeapon = true;
        }

        if (isMachinegun)
        {
            sightRange = machinegunRange;
            //tmpro.text = GetComponentInChildren<MachineGun>().lifeSpan + "";
            //ammoCounter = GetComponentInChildren<MachineGun>().lifeSpan;
            //ammoCounter = 15;
            isPistol = false;
            isShotgun = false;
            hasWeapon = true;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            audioManager.Play("Death");
            GameObject.Find("GameManager").GetComponent<Menus>().DeathScreen();
        }
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }


        //AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < AllEnemies.Count; i++)
        {
            distance = Vector3.Distance(this.transform.position, AllEnemies[i].transform.position);

            if (distance < nearestDistance)
            {
                NearestEnemy = AllEnemies[i];
                nearestDistance = distance;
                transform.LookAt(AllEnemies[i].transform);
            }
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            navAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    public void IncreaseHealth(int health)
    {
        currentHealth += health;
        healthbar.SetHealth(currentHealth);
        audioManager.Play("Healthpack");
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, ground))
        {
            walkPointSet = true;
        }
    }

    private void Retreat()
    {
        transform.LookAt(AllEnemies[0].transform);
        navAgent.SetDestination(transform.position - AllEnemies[0].transform.position);
    }

    public void TakeDamage(int damage)//, Vector3 direction)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        audioManager.Play("Ouch");

        //Knockback(direction);
    }

   // private void Knockback(Vector3 direction)
   // {
   //     Debug.Log("Knockem");
   //     knockbackCounter = knockbackTime;
   //
   //     transform.forward = direction * knockbackForce;
   // }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
