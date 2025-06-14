using UnityEngine;

public class slide : MonoBehaviour
{
    private Rigidbody rb;
    public PhysicsMaterial pm;
    public float forceForward = 100f;
    public float friction = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ccontroller();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            pm.dynamicFriction = friction;
            rb.AddForce(0, 0, forceForward, ForceMode.Impulse);
        }
    }
}
