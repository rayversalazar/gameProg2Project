using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    int animParameterID = Animator.StringToHash("Idle");
    public override void Initialize()
    {
        base.Initialize();

    }
    public override void OnEnter(EnemyStateMachine state)
    {
        base.OnEnter(state);
        baseEnemyAnimator.SetBool(animParameterID, true);
    }


    public override void ProcessAbility(EnemyStateMachine state)
    {
        
    }
    public override void FixedProcessAbility(EnemyStateMachine state)
    {
        
    }
    public override void OnExit(EnemyStateMachine state)
    {
        baseEnemyAnimator.SetBool(animParameterID, false);
    }
}
