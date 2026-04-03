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
        Collider2D detection = Physics2D.OverlapCircle(detectionZone.transform.position, detectionZoneRadius, target);
        playerPosition = detection.transform;
        return detection;
    }
    public float PlayerPositionX()
    {

        if (PlayerDetectionZone())
            return playerPosition.position.x > transform.position.x ? 1f : -1f;
        else return 0;
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
