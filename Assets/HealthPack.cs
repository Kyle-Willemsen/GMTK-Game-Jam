using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private Transform playerPickupTransform;
    public GameObject itemHands;
    public int healthAmount;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerPickupTransform = GameObject.Find("PickUpLocation").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioManager.Play("PlayerPickUp");
            Destroy(gameObject);
            Instantiate(itemHands, playerPickupTransform.position, Quaternion.identity, playerPickupTransform);
        }
        if (other.gameObject.tag == "Hero")
        {
            other.gameObject.GetComponent<HeroMovement>().IncreaseHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
