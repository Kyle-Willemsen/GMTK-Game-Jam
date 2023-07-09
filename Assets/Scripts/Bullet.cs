using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float lifeSpan;
    //public float knockbackForce;
    //private Vector3 forceImpulse;
    //public float force;
    //public float upwardForce;

    private void Start()
    {
        transform.Rotate(90, 0, 0);
        Destroy(gameObject, lifeSpan);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //forceImpulse = gameObject.transform.forward * force + transform.up * upwardForce;
        if (collision.gameObject.tag == "Enemy")
        {
            // Vector3 hitDireciton = collision.transform.position - transform.position;
            // hitDireciton = hitDireciton.normalized;

            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);//, hitDireciton);
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(forceImpulse, ForceMode.Impulse);
            Destroy(gameObject);
            CameraShake.Instance.ShakeCamera(1.6f, .1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
