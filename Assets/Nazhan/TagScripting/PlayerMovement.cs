using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    GameManager gameManager;
    public CharacterController cc;
    public float fowardSpeed = 5f;
    public float sideSpeed = 10.0f;
    //public float rightLimit = 5.5f;
    //public float leftLimit = -5.5f;
    public float jumpForce = 7f;
    public float gravity;
    public Vector3 velocity;
    public float playerHealth = 100f;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode skillKey = KeyCode.LeftShift;

    public bool disablePlayer = false;

    private Rigidbody rb;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ccontroller();
    }

    // Update is called once per frame
    void Update()
    {
        fowardAlways();
        sideMovment();
        jumping();
        //sideLimit();
        bool isGrounded = cc.isGrounded;
    }

    public void fowardAlways()
    {
        transform.Translate(Vector3.forward * fowardSpeed * Time.deltaTime, Space.World);

    }

    public void ccontroller()
    {
        cc = GetComponent<CharacterController>();
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

    /*
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
    */

    public void jumping()
    {
        bool isGrounded = cc.isGrounded;
        bool canBhop = false;
        bool jumped = Input.GetKeyDown(KeyCode.Space);

        if (canBhop)
        {
            jumped = Input.GetKey(KeyCode.Space);
        }

        if (jumped && isGrounded)
        {
            velocity.y = jumpForce;

            //JumpingState();
        }
        else if (!isGrounded)
        {
            velocity.y -= gravity;
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy, Obstacle")

        {
            StartCoroutine(Damaged());

            playerHealth = playerHealth - 40f;

            if (playerHealth <= 0f)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "EnemyChase")
        {
            gameManager.gameOver = true;
            collision.gameObject.SetActive(false);

        }
    }
    
    IEnumerator Damaged()
    {
        disablePlayer = true;
        yield return new WaitForSeconds(0.5f);
        disablePlayer = false;
    }
}
