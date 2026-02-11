using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    [SerializeField] float setAttackDuration;
    float attackDuration;
    int animParameterId = Animator.StringToHash("Attack");
    public override void FixedProcessAbility(EnemyStateMachine state)
    {
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnEnter(EnemyStateMachine state)
    {
        base.OnEnter(state);
        attackDuration = setAttackDuration;
        baseEnemyHitBox.layer = LayerMask.NameToLayer("Enemy Hit Box");
        baseEnemyAnimator.SetBool(animParameterId, true);
    }

    public override void OnExit(EnemyStateMachine state)
    {
        baseEnemyHitBox.layer = 0;
        baseEnemyCooldown.StartEnemyAttackCooldown();
        baseEnemyAnimator.SetBool(animParameterId, false);
    }

    public override void ProcessAbility(EnemyStateMachine state)
    {
        attackDuration -= Time.deltaTime;
        if (attackDuration <= 0) { 
            if (!baseEnemyPhysics.PlayerAttackZoneDetection() ) 
            {
                state.ChangeState(state.enemyChase);
            } else
            {
                state.ChangeState(state.enemyIdle);
            }
        }
        
    }
}
