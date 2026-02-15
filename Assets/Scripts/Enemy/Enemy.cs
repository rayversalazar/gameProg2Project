using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    [Header("Required Components")]
    public EnemyPhysics enemyPhysics;
    public Animator enemyAnimator;
    public EnemyStateMachine stateMachine;
    public SpriteRenderer enemyRenderer;
    public GameObject EnemyHitBox;
    public EnemyCooldown enemyCooldown;

    [Header("Enemy Attributes")]
    public int defaultEnemyHP;
    public int currentEnemyHP;
    public int defaultEnemyDamage;
    public int currentEnemyDamage;

    public bool facingRight = false;

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
        currentEnemyHP = defaultEnemyHP;
        currentEnemyDamage = defaultEnemyDamage;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFlip();
    }

    private void EnemyFlip()
    {
        if (enemyPhysics.PlayerPositionX() == -1 && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
        else if (enemyPhysics.PlayerPositionX() == 1 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
    }
}
