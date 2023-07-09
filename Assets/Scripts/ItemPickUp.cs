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
    AudioManager audioManager;

    private void Start()
    {
        playerTransform = GameObject.Find("PickUpLocation").transform;
        heroHands = GameObject.Find("HeroHands").transform;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasInHands)
        {
            audioManager.Play("PlayerPickUp");
            Destroy(gameObject);
            //bCollider.enabled = false;
            Instantiate(weaponHands, playerTransform.position, Quaternion.identity, playerTransform);
            //hasInHands = true;
        }
        if (other.gameObject.tag == "Hero" && other.gameObject.GetComponent<HeroMovement>().hasWeapon == false)
        {
            if (gameObject.tag == "MachineGun")
            {
                other.gameObject.GetComponent<HeroMovement>().isMachinegun = true;
                other.gameObject.GetComponent<HeroMovement>().ammoCounter = 15;
                audioManager.Play("Machinegun Cock");
            }
            if (gameObject.tag == "Shotgun")
            {
                other.gameObject.GetComponent<HeroMovement>().isShotgun = true;
                other.gameObject.GetComponent<HeroMovement>().ammoCounter = 9;
                audioManager.Play("Shotgun Cock");
            }
            if (gameObject.tag == "Pistol")
            {
                other.gameObject.GetComponent<HeroMovement>().isPistol = true;
                other.gameObject.GetComponent<HeroMovement>().ammoCounter = 6;
                audioManager.Play("Pistol Cock");
            }

            Destroy(gameObject);
            Instantiate(weaponHero, heroHands.position, heroHands.rotation, heroHands);
        }
    }

    private void Update()
    {
        if (playerTransform.childCount > 0)
        {
            hasInHands = true;
        }
        else
        {
            hasInHands = false;
        }
    }
}
