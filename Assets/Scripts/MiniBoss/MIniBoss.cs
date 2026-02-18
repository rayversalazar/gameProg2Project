using UnityEngine;

public class MiniBoss : MonoBehaviour, IDamageable
{
    
    [Header("Required Components")]
    public MiniBossPhysics miniBossPhysics;
    public SpriteRenderer spriteRenderer;
    public GameObject hitbox;
    public Animator anim;

    [Header("Mini Boss Attributes")]
    public int defaultHP;
    public int currentHP;
    public int defaultDamage;
    public int currentDamage;
    public bool facingRight = false;
    void Start()
    {
        currentHP = defaultHP;
        currentDamage = defaultDamage;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            return;
        }
    }
    public void EnemyFlip()
    {
        if (miniBossPhysics.PlayerPositionX() == -1 && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
        else if (miniBossPhysics.PlayerPositionX() == 1 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
    }
}
