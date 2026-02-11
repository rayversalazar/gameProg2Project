using UnityEngine;

public class StateCooldown : MonoBehaviour
{
    [SerializeField] float setAttackCooldown;
    [SerializeField] float setDashCooldown;
    public float currentAttackCooldown;
    public float currentDashCooldown;

    private void Start()
    {
        currentAttackCooldown = setAttackCooldown;
        currentDashCooldown = setDashCooldown;

    }
    void Update()
    {
        if (currentAttackCooldown>0)
        {
            currentAttackCooldown -= Time.deltaTime;
        }
        if (currentDashCooldown > 0)
        {
            currentDashCooldown -= Time.deltaTime;
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
}
