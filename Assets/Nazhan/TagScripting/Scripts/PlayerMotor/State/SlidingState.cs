﻿using UnityEngine;

public class SlidingState : BaseState
{
    public float slideDuration = 1.0f;

    // Collider logic
    private Vector3 initialCenter;
    private float initialSize;
    private float slideStart;

    public override void Construct()
    {
        motor.anim?.SetTrigger("Slide");
        slideStart = Time.time;

        initialSize = motor.controller.height;
        initialCenter = motor.controller.center;

        motor.controller.height = initialSize * 0.5f;
        motor.controller.center = initialCenter * 0.5f;
    }

    public override void Destruct()
    {
        motor.controller.height = initialSize;
        motor.controller.center = initialCenter;
        motor.anim?.SetTrigger("Running");
    }

    public override void Transition()
    {
        //if (InputManager.Instance.SwipeLeft)
        //    motor.ChangeLane(-1);

        //if (InputManager.Instance.SwipeRight)
        //    motor.ChangeLane(1);

        if (!motor.isGrounded)
            motor.ChangeState(GetComponent<FallingState>());

        if (InputManager.Instance.SwipeUp)
            motor.ChangeState(GetComponent<JumpingState>());

        if (Time.time - slideStart > slideDuration)
            motor.ChangeState(GetComponent<RunningState>());
    }

    public override Vector3 ProcessMotion()
    {
        Vector3 m = Vector3.zero;

         // Horizontal movement based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        m.x = horizontalInput * motor.baseSidewaySpeed; // Left/right movement
        //m.x = motor.SnapToLane();
        m.y = -1.0f;
        m.z = motor.baseRunSpeed;

        return m;
    }
}
