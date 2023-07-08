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


    private void Start()
    {
        heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
        canShoot = true;
    }


    private void Update()
    {
        if (heroMovement.enemyInSightRange)
        {
            Invoke("Shoot", 0.5f);
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(pistolBullet, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = barrel.forward * bulletSpeed; ;
            canShoot = false;
            Invoke("FireRate", 0.8f);
        }
    }

    private void FireRate()
    {
        canShoot = true;
    }
}
