using UnityEngine;

public class WallClimbState : BaseState
{
    float inputDirection;
    float defaultGravityScale;
    int animParameter = Animator.StringToHash("WallClimb");
    //public override void FixedProcessAbility(PlayerStateMachine state)
    //{
    //    basePhysics.rigidbody.linearVelocity = Vector2.zero;
    //}

    public override void OnEnter(PlayerStateMachine state)
    {
        inputDirection = player.facingRight ? -1 : 1;
        defaultGravityScale = basePhysics.rigidbody.gravityScale;
        basePhysics.rigidbody.gravityScale = 0;
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        baseAnimator.SetBool(animParameter, true);
    }

    public override void OnExit(PlayerStateMachine state)
    {
        base.OnExit(state);
        basePhysics.rigidbody.gravityScale = defaultGravityScale;
        baseAnimator.SetBool(animParameter, false);

    }

    public override void ProcessAbility(PlayerStateMachine state)
    {

        if (baseInputControls.horizontalInput != inputDirection) {
            player.ForceFlipCharacter();
            state.ChangeState(state.idle); 
        }
        if (baseInputControls.jump.triggered && basePhysics.isWallDetected()) state.ChangeState(state.wallJump);

    }
}
