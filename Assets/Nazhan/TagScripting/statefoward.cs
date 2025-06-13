using UnityEngine;

public class Statefoward : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private bool isMovingForward = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HandleInput();
        //UpdateAnimator();
    }
    private void HandleInput()
    {
        // Check for forward movement input (W key or Up Arrow)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            isMovingForward = true;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            isMovingForward = false;
        }
    }
}
