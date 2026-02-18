using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected Enemy enemy;

    protected Animator baseEnemyAnimator;
    protected EnemyPhysics baseEnemyPhysics;
    protected SpriteRenderer baseEnemyRenderer;
    protected GameObject baseEnemyHitBox;
    protected GameObject baseEnemyHurtBox;
    protected EnemyCooldown baseEnemyCooldown;
    void Awake()
    {
        Initialize();
    }
    public virtual void Initialize() {
        enemy = GetComponent<Enemy>();

        baseEnemyAnimator = enemy.enemyAnimator;
        baseEnemyPhysics = enemy.enemyPhysics;
        baseEnemyRenderer = enemy.enemyRenderer;
        baseEnemyHitBox = enemy.EnemyHitBox;
        baseEnemyHurtBox = enemy.EnemyHurtBox;
        baseEnemyCooldown = enemy.enemyCooldown;
        
    }
    public virtual void ProcessAbility(EnemyStateMachine state)
    {
        //needs to be in the update method
    }
    public virtual void FixedProcessAbility(EnemyStateMachine state)
    {
        //needs to be in the fixed update method
    }
    public virtual void OnEnter(EnemyStateMachine state)
    {
        Debug.Log("Enemy entered " + state.enemyCurrentState + " state.");
    }
    public virtual void OnExit(EnemyStateMachine state)
    {
        //executes before transitioning to the new state
    }
}
