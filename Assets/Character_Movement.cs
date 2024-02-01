using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust the move speed to your liking
    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate the move direction in the orientation space
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply force with more realistic movement
        Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
        Vector3 currentVelocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - currentVelocity);

        // Limit the velocity change to avoid excessive sliding
        velocityChange.x = Mathf.Clamp(velocityChange.x, -1f, 1f);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -1f, 1f);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
