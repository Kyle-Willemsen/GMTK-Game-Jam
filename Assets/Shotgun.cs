using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private HeroMovement heroMovement;
    public float fireRate;
    public float bulletSpeed;
    //public float damage;
    public GameObject bullet;
    public float lifeSpan;
    bool canShoot;
    //public Transform barell;
    public List<Transform> barrels = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        heroMovement = GameObject.Find("Hero").GetComponent<HeroMovement>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
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
        Debug.Log(lifeSpan);
        //Transform[] barrels;
        //foreach (Transform b in barrels)
        //{
        //    Instantiate(bullet, barells[b].position, Quaternion.identity)
        //}
        if (canShoot)
        {
            for (int i = 0; i < barrels.Count; i++)
            {
                canShoot = false;
                lifeSpan--;
                GameObject bulletClone = Instantiate(bullet, barrels[i].position, barrels[i].rotation);
                bulletClone.GetComponent<Rigidbody>().velocity = barrels[i].forward * bulletSpeed;
                Invoke("FireRate", fireRate);
            }
        }

    }

    private void FireRate()
    {
        canShoot = true;
    }
}
