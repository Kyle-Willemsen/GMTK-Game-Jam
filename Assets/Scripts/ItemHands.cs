using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHands : MonoBehaviour
{
    public float force;
    public float upwardForce;
    private Vector3 forceImpulse;
    private Transform pickupLoc;
    //public SphereCollider sCollider;
    private GameObject player;
    //Rigidbody rb;
    public bool hasItem;
    public GameObject weapon;
    AudioManager audioManager;

    private void Start()
    {
        //sCollider.enabled = false;
        player = GameObject.Find("Player");
        //rb = gameObject.GetComponent<Rigidbody>();
        pickupLoc = GameObject.Find("PickUpLocation").transform;
        audioManager = FindObjectOfType<AudioManager>();
        hasItem = true;
    }

    private void Update()
    {

        forceImpulse = player.transform.forward * force + transform.up * upwardForce;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasItem || Input.GetKeyDown(KeyCode.Space) && hasItem)
        {
            //Throw();
            //Physics.IgnoreLayerCollision(7, 8);
            audioManager.Play("PlayerThrow");
            //Physics.IgnoreLayerCollision(7, 8);
            Destroy(gameObject);
            GameObject clone = Instantiate(weapon, pickupLoc.position, weapon.transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(forceImpulse, ForceMode.Impulse);
            //transform.parent = null;
            //Invoke("EnableCollider", 0.5f);
            hasItem = false;
        }


    }
   // private void Throw()
   // {
   //     Debug.Log("Throw");
   //     Invoke("ResetColliders", 0.5f);
   // }
   //
   // public void ResetColliders()
   // {
   //     Debug.Log("RESET");
   //     Physics.IgnoreLayerCollision(7, 8, false);
   //     
   // }

    //  private void EnableCollider()
    //  {
    //      pickupCol.enabled = true;
    //  }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        transform.parent = pickupLoc;
    //    }
    //}
}
