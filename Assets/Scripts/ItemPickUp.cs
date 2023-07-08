using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Transform playerTransform;
    //public GameObject shotgun;
    public BoxCollider bCollider;
    public Rigidbody rb;
    private Vector3 force;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            bCollider.enabled = false;
            Instantiate(this.gameObject, playerTransform.position, Quaternion.identity, playerTransform);
        }
    }

    private void Update()
    {

    }
}
