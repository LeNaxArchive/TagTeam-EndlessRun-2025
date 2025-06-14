using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    public float fowardSpeed = 2;
    public float sideSpeed = 10;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    //public Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        fowardAlways();
        sideMovment();
        //sideLimit();
        bool isGrounded = cc.isGrounded;
    }

    public void fowardAlways()
    {
        transform.Translate(Vector3.forward * fowardSpeed * Time.deltaTime, Space.World);
    }


    public void sideMovment()
    {

        //transform.Translate(Vector3.right * Time.deltaTime * sideSpeed);
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
                transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);  
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {    
                transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1); 
        }


    }

    public void sideLimit()
    {
        if (this.gameObject.transform.position.x > leftLimit)
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
        }
        
        if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1);
            }
    }

}
