using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public AudioSource coinAudioSource;
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;

    // access the HUD
    //public HudManager hud;

    //to keep our rigid body
    Rigidbody rb;

    //to keep the collider object
    Collider coll;

    //flag to keep track of whether a jump started
    bool pressedJump = false;

    // Use this for initialization
    void Start()
    {
        //get the rigid body component for later use
        rb = GetComponent<Rigidbody>();

        //get the player collider
        coll = GetComponent<Collider>();

        //refresh the HUD
        //hud.Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player walking
        WalkHandler();

        //Handle player jumping
        JumpHandler();
    }

    // Make the player walk according to user input
    void WalkHandler()
    {
        // Set x and z velocities to zero
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

        // Distance ( speed = distance / time --> distance = speed * time)
        float distance = walkSpeed * Time.deltaTime;

        // Input on x ("Horizontal")
        float hAxis = Input.GetAxis("Horizontal");

        // Input on z ("Vertical")
        float vAxis = Input.GetAxis("Vertical");

        // Movement vector
        Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);

        // Current position
        Vector3 currPosition = transform.position;

        // New position
        Vector3 newPosition = currPosition + movement;

        // Move the rigid body
        rb.MovePosition(newPosition);
    }

    // Check whether the player can jump and make it jump
    void JumpHandler()
    {
        // Jump axis
        float jAxis = Input.GetAxis("Jump");

        // Is grounded
        bool isGrounded = CheckGrounded();

        // Check if the player is pressing the jump key
        if (jAxis > 0f)
        {
            // Make sure we've not already jumped on this key press
            if (!pressedJump)
                if (!pressedJump)
                {
                // We are jumping on the current key press
                pressedJump = true;

                // Jumping vector
                Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);

                // Make the player jump by adding velocity
                rb.linearVelocity = rb.linearVelocity + jumpVector;
            }
        }
        else
        {
            // Update flag so it can jump again if we press the jump key
            pressedJump = false;
        }
    }

    // Check if the object is grounded
    bool CheckGrounded()
    {
        // Object size in x
        float sizeX = coll.bounds.size.x;
        float sizeZ = coll.bounds.size.z;
        float sizeY = coll.bounds.size.y;

        // Position of the 4 bottom corners of the game object
        // We add 0.01 in Y so that there is some distance between the point and the floor
        Vector3 corner1 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);

        // Send a short ray down the cube on all 4 corners to detect ground
        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);

        // If any corner is grounded, the object is grounded
        return (grounded1 || grounded2 || grounded3 || grounded4);
    }

    void OnTriggerEnter(Collider collider)
    {
        // Check if we ran into a coin
        if (collider.gameObject.tag == "Coin")
        {
            print("Grabbing coin..");

            // Increase score
            //GameManager.instance.IncreaseScore(1);

            //refresh the HUD
           // hud.Refresh();

            // Play coin collection sound
            //coinAudioSource.Play();

            // Destroy coin
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            // Game over
            print("game over");

            //SceneManager.LoadScene("Game Over");
        }
        else if (collider.gameObject.tag == "Goal")
        {
            print("goal reached");

            // Increase level
            //GameManager.instance.IncreaseLevel();
        }

    }
}
