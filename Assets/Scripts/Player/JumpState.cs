using UnityEngine;
using UnityEngine.InputSystem;

public class JumpState : BaseState
{
    [SerializeField] float jumpForce;
    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        
    }

    public override void Initialize()
    {
        base.Initialize();
        
    }
    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        Jump();
    }

    public override void OnExit(PlayerStateMachine state)
    {
        base.OnExit(state);
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        if (basePhysics.isGrounded())
        {
            state.ChangeState(state.idle);
        }
    }
    void Jump()
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(basePhysics.rigidbody.linearVelocityX, jumpForce);
    }
}
