using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

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
    //public TextMeshProUGUI bulletCounter;
    private void Start()
    {
        heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
        canShoot = true;
    }
    private void Update()
    {
        //bulletCounter.text = lifeSpan + "";
        if (heroMovement.enemyInSightRange)
        {
            Shoot();
        }

        if (lifeSpan <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
        
    }

    private void Shoot()
    {

        if (canShoot)
        {
            canShoot = false;
            heroMovement.ammoCounter--;
            lifeSpan--;
            GameObject bulletClone = Instantiate(bullet, barell.position, barell.rotation);
            bulletClone.GetComponent<Rigidbody>().velocity = barell.forward * bulletSpeed;
            Invoke("FireRate", fireRate);
            CameraShake.Instance.ShakeCamera(2.4f, .15f);
        }

    }

    private void FireRate()
    {
        canShoot = true;
    }
}
