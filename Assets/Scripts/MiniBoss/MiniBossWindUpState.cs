using UnityEngine;

public class MiniBossWindUpState : MiniBossBaseState
{
    public float setWindUpDuration;
    public float currentWindUpDuration;
    int animationParameterId = Animator.StringToHash("WindUp");

    public override void FixedProcessAbility(MiniBossStateMachine state)
    {
       
    }

    public override void OnEnter(MiniBossStateMachine state)
    {
        currentWindUpDuration = setWindUpDuration;
        baseAnimator.SetBool(animationParameterId, true);
    }

    public override void OnExit(MiniBossStateMachine state)
    {
        baseAnimator.SetBool(animationParameterId, false);
    }

    public override void ProcessAbility(MiniBossStateMachine state)
    {
        miniBoss.EnemyFlip();
        if (currentWindUpDuration > 0)
        {
            currentWindUpDuration -= Time.deltaTime;
            return;
        }
        if (currentWindUpDuration <= 0)
        {
            state.ChangeState(state.lunge);
        }

    }

    protected override void Initialize()
    {
        base.Initialize();
    }
}
