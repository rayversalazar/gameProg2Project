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
        if (basePhysics.isGrounded() && baseInputControls.jump.triggered)
        {
            state.ChangeState(state.jump);
        }
        //transitioning from idle to falling
        if (!basePhysics.isGrounded() && basePhysics.rigidbody.linearVelocityY < 0)
        {
            state.ChangeState(state.falling);
        }
        //transitioning to attack
        if (baseInputControls.attack.triggered)
        {
            state.ChangeState(state.attack);
        }
        //transitioning to dash
        if (baseInputControls.dash.triggered && baseCooldown.currentDashCooldown<=0)
        {
            state.ChangeState(state.dash);
        }
        //transitioning to heal
        if (baseInputControls.healInput>0f && player.currentHP<8)
        {
            state.ChangeState(state.healing);
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
