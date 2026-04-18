using UnityEngine;
using UnityEngine.InputSystem;

public class JumpState : BaseState
{
    [SerializeField] float jumpForce;
    public int jumpCount;
    public int currentJumpCount;

    public override void Initialize()
    {
        base.Initialize();
        JumpReset();
    }
    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        state.jump.currentJumpCount--;
        Jump();
        state.ChangeState(state.rising);
    }
    public void Jump()
    {
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        basePhysics.rigidbody.linearVelocity = new Vector2(basePhysics.rigidbody.linearVelocityX, jumpForce);
    }

    public void JumpReset()
    {
        currentJumpCount = jumpCount;
    }

}
