using UnityEngine;

public class FallingState : BaseState
{
    public override void Construct()
    {
        motor.anim?.SetTrigger("Fall");
    }

    public override Vector3 ProcessMotion()
    {
        // Apply gravity
        motor.ApplyGravity();

        // Create our return vector
        Vector3 m = Vector3.zero;

        
        // Get input for left/right movement
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        //m.x = motor.SnapToLane();
        m.x = horizontalInput * motor.baseSidewaySpeed; // Left/Right movement
        m.y = motor.verticalVelocity;
        m.z = motor.baseRunSpeed;

        return m;
    }

    public override void Transition()
    {
        //if (InputManager.Instance.SwipeLeft)
        //    motor.ChangeLane(-1);

        //if (InputManager.Instance.SwipeRight)
        //    motor.ChangeLane(1);

        if (motor.isGrounded)
            motor.ChangeState(GetComponent<RunningState>());
    }

}