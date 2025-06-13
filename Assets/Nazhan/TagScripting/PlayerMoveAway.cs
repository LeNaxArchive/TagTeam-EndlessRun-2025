using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAway : MonoBehaviour {
    public CharacterController cc;
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;
    public Vector3 velocity;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void Update()
    {
        float sideMovement = Input.GetAxis ("Horizontal");
        float forwardMovement = Input.GetAxis("Vertical");

        velocity.x = sideMovement;
        velocity.z = forwardMovement;
        
        bool isGrounded = cc.isGrounded;
        bool canBhop = false;
        bool jumped = Input.GetKeyDown (KeyCode.Space);

        if (canBhop) {
            jumped = Input.GetKey (KeyCode.Space);
        }

        if (jumped && isGrounded)
        {
            velocity.y = jumpSpeed;
        } else if (!isGrounded)
        {
            velocity.y -= gravity;
        }

        cc.Move ((transform.rotation * velocity) * moveSpeed * Time.deltaTime);
    }
    
}