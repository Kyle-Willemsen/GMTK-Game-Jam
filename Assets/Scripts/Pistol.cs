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
    AudioManager audioManager;

    private void Start()
    {
        heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
        audioManager = FindObjectOfType<AudioManager>();
        canShoot = true;
    }


    private void Update()
    {
        if (lifeSpan <= 0)
        {
            Destroy(gameObject, 0.1f);
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
            audioManager.Play("PistolShoot");
            canShoot = false;
            heroMovement.ammoCounter--;
            lifeSpan--;
            GameObject bullet = Instantiate(pistolBullet, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = barrel.forward * bulletSpeed; ;
            Invoke("FireRate", fireRate);
            CameraShake.Instance.ShakeCamera(2, .15f);
        }
    }

    private void FireRate()
    {
        canShoot = true;
    }
}
