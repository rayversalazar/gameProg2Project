using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class Player : MonoBehaviour, IDamageable, ISetSpawnPoint
{
    [Header("Required Components")]
    public PlayerPhysics playerPhysics;
    public PlayerInputControls playerInputControls;
    public Animator animator;
    public PlayerStateMachine stateMachine;
    public StateCooldown stateCooldown;
    public SpriteRenderer spriteRenderer;
    public GameObject hitbox;
    public GameObject hurtbox;
    public PlayerAudio sfx;
    public HealthUI healthUI;

    [Header("Player Attributes")]
    [SerializeField] int setHP;
    public int currentHP;
    [SerializeField] int damage;
    public int currentDamage;
    public Vector3 currentSpawnPoint;
    public bool facingRight = true;
    public bool isHit = false;
    void Start()
    {
        currentHP = setHP;
        currentDamage = damage;
        currentSpawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        postHitImmunity();
    }

    public void postHitImmunity()
    {
        if (stateCooldown.currentPostHitImmunityCooldown > 0 && !isHit)
        {
            hurtbox.layer = LayerMask.NameToLayer("Player Immunity");
            isHit = !isHit; // switch
        } else if (stateCooldown.currentPostHitImmunityCooldown <= 0 && isHit)
        {
            isHit = !isHit;
            hurtbox.layer = LayerMask.NameToLayer("Player Hurt Box");
        }

    }

    public void Respawn()
    {
        transform.position = currentSpawnPoint;
    }

    public void FlipCharacter()
    {
        if (playerInputControls.horizontalInput < 0 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;// this is like a switch
        } else if (playerInputControls.horizontalInput > 0 && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
    }
    public void ForceFlipCharacter(){
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
    public void TakeDamage(int damage, Vector3 enemy)
    {
        currentHP -= damage;
        currentHP =  Mathf.Clamp(currentHP, 0, setHP);
        if (currentHP == 0)
        {
            Debug.Log("yatap");
            return;
        }
        healthUI.UpdateHealthBar(currentHP, setHP);
        stateMachine.knockback.knockbackDirection = enemy.x > transform.position.x ? -1 : 1;
        stateMachine.ChangeState(stateMachine.knockback);
        stateCooldown.startPostHitImmunityCooldown();
    }
    public void TakeDamage(int damage)
    {

    }

    public void setSpawnPoint(Vector3 newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
    }
    public void HealHP(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, setHP);
        healthUI.UpdateHealthBar(currentHP, setHP);
    }
}
