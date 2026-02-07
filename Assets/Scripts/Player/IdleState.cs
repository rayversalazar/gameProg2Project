using UnityEngine;

public class IdleState : BaseState
{
    //for animation
    string idleParemeterName = "Idle";
    int idleParameterID;


    public override void ProcessAbility(PlayerStateMachine state)
    {
        if (baseInputControls.horizontalInput!=0)
        {
            state.ChangeState(state.walk);
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
