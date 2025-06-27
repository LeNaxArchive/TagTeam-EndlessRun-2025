using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour

{
    public float speed = 5f;
    public float jumpForce = 5f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float moveX = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveX, 0, speed);
        controller.Move(move * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += jumpForce;
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
