using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBobble : MonoBehaviour
{
    Vector3 bobFrom;
    Vector3 bobTo;
    Vector3 offset = new Vector3(0, 1.5f);
    public float moveSpeed;
    Vector3 bobbingDestination;

    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        offset = Vector3.down;
        bobFrom = transform.position;
        bobTo = transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == bobFrom)
        {
            bobbingDestination = bobTo;
        }
        if (transform.position == bobTo)
        {
            bobbingDestination = bobFrom;
        }

        transform.position = Vector3.MoveTowards(transform.position, bobbingDestination, moveSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, spinSpeed, 0));
    }
}
