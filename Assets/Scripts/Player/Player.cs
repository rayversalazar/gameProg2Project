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

    private bool facingRight = false;
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

    public void TakeDamage(IDamageDealer damageDealer, Transform other)
    {
        currentHP -= damageDealer.Damage;
        if (currentHP <= 0)
        {
            Debug.Log("yatap");
            return;
        }

    }
}
