using UnityEngine;

public class MiniBossAttackState : MiniBossBaseState
{
    public override void FixedProcessAbility(MiniBossStateMachine state)
    {
    }

    public override void OnEnter(MiniBossStateMachine state)
    {
        base.OnEnter(state);
        state.ChangeState(state.windUp);
    }

    public override void OnExit(MiniBossStateMachine state)
    {
        base.OnExit(state);
    }

    public override void ProcessAbility(MiniBossStateMachine state)
    {
        //if (!basePhysics.PlayerAttackZoneDetection()) state.ChangeState(state.chase);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

}
