using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    [SerializeField] float chaseSpeed;
    [SerializeField] float direction;
    int animParameterId = Animator.StringToHash("Chase");
    public override void FixedProcessAbility(EnemyStateMachine state)
    {
        if (baseEnemyPhysics.PlayerAttackZoneDetection() && baseEnemyCooldown.currentAttackCooldown > 0)
        {
            baseEnemyPhysics.enemyRigidbody.linearVelocity = Vector2.zero;
            return;//stop when near the enemy and attack is in cooldown
        }

        baseEnemyPhysics.enemyRigidbody.linearVelocity = new Vector2(chaseSpeed * direction, baseEnemyPhysics.enemyRigidbody.linearVelocityY);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnEnter(EnemyStateMachine state)
    {
        base.OnEnter(state);
        baseEnemyAnimator.SetBool(animParameterId, true);
    }

    public override void OnExit(EnemyStateMachine state)
    {
        baseEnemyAnimator.SetBool(animParameterId, false);
        baseEnemyPhysics.enemyRigidbody.linearVelocity = Vector2.zero;
        baseEnemyCooldown.StartEnemyDetectionCooldown();

    }

    public override void ProcessAbility(EnemyStateMachine state)
    {
        direction = baseEnemyPhysics.PlayerPositionX();
        if (!baseEnemyPhysics.PlayerDetectionZone() || baseEnemyCooldown.currentAttackCooldown > 0)
        {
            state.ChangeState(state.enemyIdle);
        }
        if (baseEnemyPhysics.PlayerAttackZoneDetection() && baseEnemyCooldown.currentAttackCooldown<=0)
        {
            state.ChangeState(state.enemyAttack);
        }
       
    }
}
