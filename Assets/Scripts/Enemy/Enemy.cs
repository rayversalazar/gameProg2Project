using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    [Header("Required Components")]
    public EnemyPhysics enemyPhysics;
    public Animator enemyAnimator;
    public EnemyStateMachine stateMachine;

    [Header("Required Components")]
    public int enemyHP;
    public int currentEnemyHP;

    public void TakeDamage(int damage, Vector3 player)
    {
        currentEnemyHP -= damage;
        if (currentEnemyHP <= 0)
        {
            gameObject.SetActive(false);
            return;
        }
        stateMachine.enemyKnockback.knockbackDirection = player.x > transform.position.x ? -1 : 1;
        stateMachine.ChangeState(stateMachine.enemyKnockback);


    }
    public void TakeDamage(int damage)
    {

    }

    void Start()
    {
        currentEnemyHP = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
