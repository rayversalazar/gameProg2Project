using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    [Header("Required Components")]
    public EnemyPhysics enemyPhysics;
    public Animator enemyAnimator;

    [Header("Required Components")]
    public int enemyHP;
    public int currentEnemyHP;

    public void TakeDamage(int damage)
    {
        currentEnemyHP -= damage;
        if (currentEnemyHP <= 0)
        {
            gameObject.SetActive(false);
        }
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
