using UnityEngine;

public class MiniBossRestState : MiniBossBaseState
{
    public float setRestDuration;
    public float currentRestDuration;
    int animationParameterId = Animator.StringToHash("Rest");

    public override void OnEnter(MiniBossStateMachine state)
    {
        base.OnEnter(state);
        currentRestDuration = setRestDuration;
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        baseAnimator.SetBool(animationParameterId, true);
    }

    public override void OnExit(MiniBossStateMachine state)
    {
        baseAnimator.SetBool(animationParameterId, false);
    }

    public override void ProcessAbility(MiniBossStateMachine state)
    {
       if (currentRestDuration > 0)
        {
            currentRestDuration -= Time.deltaTime;
            return;
        }
        state.ChangeState(state.idle);
    }

}
