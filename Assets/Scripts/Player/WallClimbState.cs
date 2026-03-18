using UnityEngine;

public class WallClimbState : BaseState
{
    float inputDirection;
    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        inputDirection = player.facingRight ? -1 : 1;
    }

    public override void OnExit(PlayerStateMachine state)
    {
        base.OnExit(state);
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {

        if (baseInputControls.horizontalInput != inputDirection) state.ChangeState(state.idle);
        if (baseInputControls.jumpActionRef.action.triggered && basePhysics.isWallDetected()) state.ChangeState(state.wallJump);

    }
}
