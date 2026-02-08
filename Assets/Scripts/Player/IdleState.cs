using UnityEngine;

public class IdleState : BaseState
{
    //for animation
    string idleParemeterName = "Idle";
    int idleParameterID;


    public override void ProcessAbility(PlayerStateMachine state)
    {
        //transitioning to idle to walk
        if (baseInputControls.horizontalInput!=0 && basePhysics.isGrounded())
        {
            state.ChangeState(state.walk);
        }
        //transitioning to idle to jump
        if (basePhysics.isGrounded() && baseInputControls.jumpActionRef.action.triggered)
        {
            state.ChangeState(state.jump);
        }
        //transitioning from idle to falling
        if (!basePhysics.isGrounded() && basePhysics.rigidbody.linearVelocityY < 0)
        {
            state.ChangeState(state.falling);
        }
    }
    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(idleParameterID, true);
    }
    public override void Initialize()
    {
        base.Initialize();
        idleParameterID = Animator.StringToHash(idleParemeterName);
    }
    public override void OnExit(PlayerStateMachine state)
    {
        base.OnExit(state);
        baseAnimator.SetBool(idleParameterID, false);
    }
}
