﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : BaseState
{
    public override void Construct()
    {
        motor.verticalVelocity = 0;
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

    public override void Transition()
    {
        //if (InputManager.Instance.SwipeLeft)
        //    motor.ChangeLane(-1);

        //if (InputManager.Instance.SwipeRight)
        //    motor.ChangeLane(1);

        if (InputManager.Instance.SwipeUp && motor.isGrounded)
            motor.ChangeState(GetComponent<JumpingState>());

        if(!motor.isGrounded)
            motor.ChangeState(GetComponent<FallingState>());

        if (InputManager.Instance.SwipeDown)
            motor.ChangeState(GetComponent<SlidingState>());
    }
}
