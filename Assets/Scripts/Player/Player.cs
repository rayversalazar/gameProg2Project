using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Required Components")]
    public PlayerPhysics playerPhysics;
    public PlayerInputControls playerInputControls;
    public Animator animator;
    public PlayerStateMachine stateMachine;

    [Header("Player Attributes")] 
    [SerializeField] int MaxHP;
    [SerializeField] int currentHP;

    public bool facingRight = true;
    void Start()
    {
        currentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void FlipCharacter()
    {
        if (playerInputControls.horizontalInput < 0 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;// this is like a switch
        } else if (playerInputControls.horizontalInput  >0 && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
    }

    public void TakeDamage(int damage, Vector3 enemy)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log("yatap");
            return;
        }
        stateMachine.knockback.knockbackDirection = enemy.x > transform.position.x ? 1 : -1;
        stateMachine.ChangeState(stateMachine.knockback);
    }
    public void TakeDamage(int damage)
    {

    }
}
