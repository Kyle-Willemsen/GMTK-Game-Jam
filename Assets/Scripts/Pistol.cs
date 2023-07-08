using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    HeroMovement heroMovement;
    public GameObject pistolBullet;
    public Transform barrel;
    private bool canShoot;
    public float bulletSpeed;
    public float fireRate;
    public float lifeSpan;


    private void Start()
    {
        heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
        canShoot = true;
    }


    private void Update()
    {
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }

        if (heroMovement.enemyInSightRange)
        {
            Invoke("Shoot", 0.2f);
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            lifeSpan--;
            GameObject bullet = Instantiate(pistolBullet, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = barrel.forward * bulletSpeed; ;
            Invoke("FireRate", fireRate);
        }
    }

    private void FireRate()
    {
        canShoot = true;
    }
}
