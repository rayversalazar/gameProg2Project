using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D enemyRigidbody;
    public GameObject detectionZone;
    [SerializeField] float detectionZoneRadius;
    public GameObject attackZone;
    [SerializeField] float attackZoneRadius;
    [SerializeField] LayerMask target;
    [SerializeField] Transform playerPosition;
    public bool PlayerDetectionZone()
    {
        return  Physics2D.OverlapCircle(detectionZone.transform.position, detectionZoneRadius, target);
    }
    public float PlayerPositionX()
    {
        return playerPosition.position.x > transform.position.x ? 1f : -1f;
    }
    private void OnDrawGizmos()
    {
        //for detection
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionZone.transform.position, detectionZoneRadius);
        //for attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackZone.transform.position, attackZoneRadius);
    }

    public bool PlayerAttackZoneDetection()
    {
        return  Physics2D.OverlapCircle(attackZone.transform.position, attackZoneRadius, target);
    }
}
