using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float lifeSpan;

    private void Start()
    {
        transform.Rotate(90, 0, 0);
        Destroy(gameObject, lifeSpan);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
            CameraShake.Instance.ShakeCamera(1.6f, .1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
