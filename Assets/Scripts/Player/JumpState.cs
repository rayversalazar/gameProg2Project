using UnityEngine;
using UnityEngine.InputSystem;

public class JumpState : BaseState
{
    [SerializeField] float jumpForce;

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        Jump();
        state.ChangeState(state.rising);
    }
    public void Jump()
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(basePhysics.rigidbody.linearVelocityX, jumpForce);
    }
}
