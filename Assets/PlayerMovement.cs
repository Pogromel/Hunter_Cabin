using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    
    public float crouchSpeed;
    public float CrouchYScale ;
    private float startYScale;
    
    private float speed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public KeyCode crouchkey = KeyCode.LeftControl;
    
    public Transform groundCheck;
    public float Orientation = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;

    private bool isCrouching;
    private bool isGrounded;

    private void Start()
    {
        
        startYScale = transform.localScale.y;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, Orientation, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isCrouching == true)
        {
            speed = 6f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        if (Input.GetKeyDown(crouchkey))
        {
            transform.localScale = new Vector3(transform.localScale.x, CrouchYScale, transform.localScale.z);
            speed = 2f;
        }
        
        if (Input.GetKeyUp(crouchkey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            speed = 12f;
        }
        
        
        
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
