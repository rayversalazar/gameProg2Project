using UnityEngine;

public class WallJumpState : BaseState
{
    [SerializeField] float wallJumpForceX;
    [SerializeField] float wallJumpForceY;
    [SerializeField] float wallJumpDuration;
    [SerializeField] float time;
    [SerializeField] float wallJumpMinimumTime;
    [SerializeField] float minimumTime;


    float oppositeDirection;


    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        oppositeDirection = player.facingRight ? 1 : -1;
        basePhysics.rigidbody.AddForce(new Vector2(wallJumpForceX * oppositeDirection, wallJumpForceY), ForceMode2D.Impulse);
        time = wallJumpDuration;
        minimumTime = wallJumpMinimumTime;
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        time -= Time.deltaTime;
        minimumTime -= Time.deltaTime;
        if (baseInputControls.jumpInput == 0f && wallJumpMinimumTime<=0) time = 0;
        if (time <= 0) state.ChangeState(state.falling);
    }

    public override void OnExit(PlayerStateMachine state)
    {
        base.OnExit(state);
    }
}
