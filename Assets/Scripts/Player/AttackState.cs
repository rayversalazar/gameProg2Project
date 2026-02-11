using UnityEngine;

public class AttackState : BaseState
{
    [SerializeField] float setAttackDuration;
    float attackDuration;
    int animParameterId = Animator.StringToHash("Attack");

    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        base.FixedProcessAbility(state);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        attackDuration = setAttackDuration;
        baseAnimator.SetBool(animParameterId, true);

    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseCooldown.startAttackCooldown();
        baseAnimator.SetBool(animParameterId, false);
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
         attackDuration -= Time.deltaTime;
        if (attackDuration <= 0)
        {
            if (baseInputControls.horizontalInput==0)
            state.ChangeState(state.idle);
            else state.ChangeState(state.walk);
        }
    }
}
