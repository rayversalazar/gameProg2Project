using UnityEngine;

public class MiniBossIdleState : MiniBossBaseState
{
    int animationParameterId = Animator.StringToHash("Idle");
    public override void FixedProcessAbility(MiniBossStateMachine state)
    {
        base.FixedProcessAbility(state);
    }

    public override void OnEnter(MiniBossStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(animationParameterId, true);
    }

    public override void OnExit(MiniBossStateMachine state)
    {
       baseAnimator.SetBool(animationParameterId, false);
    }

    public override void ProcessAbility(MiniBossStateMachine state)
    {
        if (basePhysics.PlayerDetectionZone()) state.ChangeState(state.chase);
    }
}
