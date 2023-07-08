using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTimer;
    private Vector3 offset = new Vector3(0, 3, 0);
    private Vector3 randomOffset = new Vector3(1f, 0, 0);

    private void Start()
    {
        Destroy(gameObject, destroyTimer);
        //gameObject.transform.Rotate(45, 0, 0);
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomOffset.x, randomOffset.x),
        Random.Range(-randomOffset.y, -randomOffset.y),
        Random.Range(-randomOffset.z, randomOffset.z));
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
