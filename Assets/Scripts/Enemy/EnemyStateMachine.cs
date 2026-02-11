using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{

    public EnemyBaseState enemyCurrentState;
    public EnemyIdleState enemyIdle;
    public EnemyKnockbackState enemyKnockback;
    public EnemyChaseState enemyChase;
    public EnemyAttackState enemyAttack;

    private void Awake()
    {
        enemyCurrentState = enemyIdle;
    }
    void Start()
    {
        enemyCurrentState.OnEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCurrentState.ProcessAbility(this);
    }
    private void FixedUpdate()
    {
        enemyCurrentState.FixedProcessAbility(this);
    }
    public void ChangeState(EnemyBaseState newState)
    {
        enemyCurrentState.OnExit(this);
        enemyCurrentState = newState;
        enemyCurrentState.OnEnter(this);
    }
}
