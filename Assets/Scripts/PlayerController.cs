using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float playerSpeed;
    public Vector3 facingDir;
    private Vector3 pointToLook;
    private Vector3 move;
    Camera cam;
    //bool hasItem;

    [Header("Gravity")]
    public LayerMask layermask;
    public float groundDistance = 0.4f;
    public bool isGrounded;
    public Transform groundCheck;
    private Vector3 velocity;
    public float gravity;



    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cam = Camera.main;
    }

    private void Update()
    {
        Movement();
        MouseLook();
        Gravity();
    }

    private void Movement()
    {
      
        facingDir = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);

        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            transform.LookAt(facingDir);
        }
        

    }

    private void MouseLook()
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(mousePos, out rayLength))
        {
            pointToLook = mousePos.GetPoint(rayLength);

            transform.LookAt(facingDir);
        }
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, layermask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
