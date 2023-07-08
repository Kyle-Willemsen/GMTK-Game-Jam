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


    private void Start()
    {
        currentHealth = maxHealth;

        navAgent = gameObject.GetComponent<NavMeshAgent>();
        navAgent.speed = playerSpeed;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        
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
            tmpro.text = GetComponentInChildren<Pistol>().lifeSpan + "";
            isShotgun = false;
            isMachinegun = false;
        }

        if (isShotgun)
        {
            sightRange = shotgunRange;
            tmpro.text = GetComponentInChildren<Shotgun>().lifeSpan + "";
            isPistol = false;
            isMachinegun = false;
        }

        if (isMachinegun)
        {
            sightRange = machinegunRange;
            tmpro.text = GetComponentInChildren<MachineGun>().lifeSpan + "";
            isPistol = false;
            isShotgun = false;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
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
        Debug.Log("Patrolling");
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
        Debug.Log("retreating");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
