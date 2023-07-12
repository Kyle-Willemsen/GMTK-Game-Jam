using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject crosshair;


    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        crosshair.transform.position = mouse;
    }
}
