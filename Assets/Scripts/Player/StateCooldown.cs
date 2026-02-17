using UnityEngine;

public class StateCooldown : MonoBehaviour
{
    [SerializeField]Player player;

    [SerializeField] float setAttackCooldown;
    [SerializeField] float setDashCooldown;
    [SerializeField] float setPostHitImmunityCooldown;
    public float currentAttackCooldown;
    public float currentDashCooldown;
    public float currentPostHitImmunityCooldown;

    private void Awake()
    {
    }

    private void Start()
    {
        currentAttackCooldown = setAttackCooldown;
        currentDashCooldown = setDashCooldown;
        currentPostHitImmunityCooldown = setPostHitImmunityCooldown;

    }
    void Update()
    {
        Debug.Log("state cooldown update");
        if (currentAttackCooldown>0)
        {
            currentAttackCooldown -= Time.deltaTime;
        }
        if (currentDashCooldown > 0)
        {
            currentDashCooldown -= Time.deltaTime;
        }
        if (currentPostHitImmunityCooldown > 0)
        {
            currentPostHitImmunityCooldown -= Time.deltaTime;
        }
        
    }
    public void startAttackCooldown()
    {
        currentAttackCooldown = setAttackCooldown;
    }
    public void startDashCooldown()
    {
        currentDashCooldown = setDashCooldown;
    }
    public void startPostHitImmunityCooldown()
    {
        currentPostHitImmunityCooldown = setPostHitImmunityCooldown;
    }
}
