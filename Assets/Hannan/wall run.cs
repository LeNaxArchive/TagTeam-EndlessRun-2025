using UnityEngine;

public class wallrun : MonoBehaviour
{   
    //GameObject player;
    private Rigidbody rb;

    public float speed = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //ccontroller();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.AddForce(move * speed);
        Debug.Log(rb.linearVelocity);

    }
}
