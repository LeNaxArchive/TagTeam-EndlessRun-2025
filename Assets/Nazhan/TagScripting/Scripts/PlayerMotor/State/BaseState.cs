using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseState : MonoBehaviour
{
    protected PlayerMotor motor;

    public virtual void Construct() { }
    public virtual void Destruct() { }
    public virtual void Transition() { }

    private void Awake()
    {
        motor = GetComponent<PlayerMotor>();
    }

    /*public virtual Vector3 ProcessMotion()
    {
        Debug.Log("Process motion is not implemented in " + this.ToString());
        return Vector3.zero;
    }*/

    public virtual Vector3 ProcessMotion()
    {
        // Get input for left/right movement
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        float forwardMovement = motor.baseRunSpeed; // Constant forward speed
        // Create the movement vector
        Vector3 move = new Vector3(horizontalInput * motor.baseSidewaySpeed, 0, forwardMovement);
        return move;
    }
    
}
