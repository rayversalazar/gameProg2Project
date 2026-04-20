using UnityEngine;

public class SoleStateIdle : SoleBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int animParam;
    [SerializeField]float setWaitTime;
    [SerializeField]float currentWaitTime;
    bool stateSwitch;
    public override void FixedProcessAbility(SoleStateMachine state)
    {
        base.FixedProcessAbility(state);
        if (currentWaitTime >= 0)
        {
            currentWaitTime -= Time.fixedDeltaTime;
        }

    }

    public override void OnEnter(SoleStateMachine state)
    {
        base.OnEnter(state);
        soleAnimator.SetBool(animParam, true);
        stateSwitch = !stateSwitch;
        
    }

    public override void OnExit(SoleStateMachine state)
    {
        base.OnExit(state);
        soleAnimator.SetBool(animParam, false);
        currentWaitTime = setWaitTime;
    }

    public override void ProcessAbility(SoleStateMachine state)
    {
        base.ProcessAbility(state);
        if(solePhysics.PlayerDetected()&&currentWaitTime<0)
        {
            if (stateSwitch) state.ChangeState(state.soleCleave);
            else state.ChangeState(state.soleDismantle);
        }
        
    }

    protected override void Initialize()
    {
        base.Initialize();
        animParam = Animator.StringToHash("idle");
    }
}
