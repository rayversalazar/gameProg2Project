using UnityEngine;

public class Sole : MonoBehaviour, IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Required Components")]
    public Animator animator;
    public SolePhysics physics;
    public SoleStateMachine stateMachine;

    [Header("Player Attributes")]
    public int setHealth;
    public int currentHealth;
    public int damage;
    public bool facingRight = true;
    void Start()
    {
        currentHealth = setHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void soleFlip()
    {
        if (physics.PlayerDirectionX() == -1 && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
        else if (physics.PlayerDirectionX() == 1 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("ouch");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
