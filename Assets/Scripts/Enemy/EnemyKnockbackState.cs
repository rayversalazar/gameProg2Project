using UnityEngine;

public class EnemyKnockbackState : EnemyBaseState
{
    [SerializeField] float knockbackForceX;
    [SerializeField] float knockbackForceY;
    [SerializeField] float knockbackStateDuration;
    [SerializeField] float time;
    public int knockbackDirection;
    public override void FixedProcessAbility(EnemyStateMachine state)
    {
        base.FixedProcessAbility(state);
    }

    public override void OnEnter(EnemyStateMachine state)
    {
        base.OnEnter(state);
        time = knockbackStateDuration;
        baseEnemyRenderer.color = Color.red;
        baseEnemyPhysics.enemyRigidbody.linearVelocity = Vector2.zero;

        baseEnemyPhysics.enemyRigidbody.AddForce(new Vector2(knockbackDirection * knockbackForceX, knockbackForceY), ForceMode2D.Impulse);
    }

    public override void OnExit(EnemyStateMachine state)
    {
        baseEnemyRenderer.color = Color.white;
        baseEnemyPhysics.enemyRigidbody.linearVelocity = Vector2.zero;
    }

    public override void ProcessAbility(EnemyStateMachine state)
    {

        time -= Time.deltaTime;
        if (time <= 0)
        {
           
                state.ChangeState(state.enemyIdle);

        }
    }
}
