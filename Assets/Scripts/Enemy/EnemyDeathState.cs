using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    [SerializeField] float fadeSpeed;
    Color currentColor;
    public override void FixedProcessAbility(EnemyStateMachine state)
    {
        base.FixedProcessAbility(state);
    }

    public override void OnEnter(EnemyStateMachine state)
    {
        baseEnemyHurtBox.layer = 0;
    }

    public override void OnExit(EnemyStateMachine state)
    {
        base.OnExit(state);
    }

    public override void ProcessAbility(EnemyStateMachine state)
    {
        currentColor = baseEnemyRenderer.color;
        currentColor.a -= fadeSpeed * Time.deltaTime;
        baseEnemyRenderer.color = currentColor;
        if (currentColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
