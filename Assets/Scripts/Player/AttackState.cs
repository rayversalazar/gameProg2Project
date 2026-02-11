using UnityEngine;

public class AttackState : BaseState
{
    [SerializeField] float setAttackDuration;
    float attackDuration;
    int animParameterId = Animator.StringToHash("Attack");


    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        baseHitbox.layer = LayerMask.NameToLayer("Player Hit Box");
        attackDuration = setAttackDuration;
        baseAnimator.SetBool(animParameterId, true);
        

    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseCooldown.startAttackCooldown();
        baseAnimator.SetBool(animParameterId, false);
        baseHitbox.layer = 0;
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
