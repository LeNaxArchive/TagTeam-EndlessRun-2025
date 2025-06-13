using UnityEngine;

public class FallingState : BaseState
{
    public override void Construct()
    {
        motor.anim?.SetTrigger("Fall");
    }

    

    public override void Transition()
    {


        if (motor.isGrounded)
            motor.ChangeState(GetComponent<RunningState>());
    }
}