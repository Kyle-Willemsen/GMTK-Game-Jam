using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject weaponHands;
    public GameObject weaponHero;
    private Transform heroHands;
    //public BoxCollider bCollider;
    bool hasInHands;
    //public Rigidbody rb;
    //private Vector3 force;

    private void Start()
    {
        playerTransform = GameObject.Find("PickUpLocation").transform;
        heroHands = GameObject.Find("HeroHands").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //bCollider.enabled = false;
            Instantiate(weaponHands, playerTransform.position, Quaternion.identity, playerTransform);
        }
        if (other.gameObject.tag == "Hero")
        {
            if (gameObject.tag == "MachineGun")
            {
                other.gameObject.GetComponent<HeroMovement>().isMachinegun = true;
            }
            if (gameObject.tag == "Shotgun")
            {
                other.gameObject.GetComponent<HeroMovement>().isShotgun = true;
            }
            if (gameObject.tag == "Pistol")
            {
                other.gameObject.GetComponent<HeroMovement>().isPistol = true;
            }
            Destroy(gameObject);
            Instantiate(weaponHero, heroHands.position, heroHands.rotation, heroHands);
        }
    }

    private void Update()
    {

    }
}
