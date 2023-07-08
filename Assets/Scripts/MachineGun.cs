using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    private HeroMovement heroMovement;
    public float fireRate;
    public float bulletSpeed;
    //public float damage;
    public GameObject bullet;
    public float lifeSpan;
    bool canShoot;
    public Transform barell;

    private void Start()
    {
        heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
        canShoot = true;
    }
    private void Update()
    {
        if (heroMovement.enemyInSightRange)
        {
            Shoot();
        }

        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void Shoot()
    {

        if (canShoot)
        {
            canShoot = false;
            lifeSpan--;
            GameObject bulletClone = Instantiate(bullet, barell.position, barell.rotation);
            bulletClone.GetComponent<Rigidbody>().velocity = barell.forward * bulletSpeed;
            Invoke("FireRate", fireRate);
        }

    }

    private void FireRate()
    {
        canShoot = true;
    }
}
