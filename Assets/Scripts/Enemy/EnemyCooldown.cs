using UnityEngine;

public class EnemyCooldown : MonoBehaviour
{
    [SerializeField] float setAttackCooldown;
    public float currentAttackCooldown;
    [SerializeField] float setDetectionCooldown;
    public float currentDetectionCooldown;
    void Start()
    {
        currentAttackCooldown = setAttackCooldown;
        currentDetectionCooldown = setDetectionCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAttackCooldown > 0)
        {
            currentAttackCooldown -= Time.deltaTime;
        }
        if (currentDetectionCooldown > 0)
        {
            currentDetectionCooldown -= Time.deltaTime;
        }
    }
    public void StartEnemyAttackCooldown()
    {
        currentAttackCooldown = setAttackCooldown;
    }
    public void StartEnemyDetectionCooldown()
    {
        currentDetectionCooldown = setDetectionCooldown;
    }
}
