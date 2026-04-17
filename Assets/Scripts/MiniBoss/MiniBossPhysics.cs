using UnityEngine;

public class MiniBossPhysics : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] GameObject chaseRange;
    [SerializeField] float chaseRangeRadius;
    [SerializeField] GameObject attackRange;
    [SerializeField] float attackRangeRadius;
    [SerializeField] LayerMask target;
    [SerializeField] Transform playerPosition;

    public bool PlayerDetectionZone()
    {
        Collider2D detection = Physics2D.OverlapCircle(chaseRange.transform.position, chaseRangeRadius, target);
        if (detection != null)
        {
            playerPosition = detection.transform;
            return true;
        }
        return false;
    }
    public float PlayerPositionX()
    {
        if (PlayerDetectionZone())
            return playerPosition.position.x > transform.position.x ? 1f : -1f;
        return 0;
    }
    private void OnDrawGizmos()
    {
        //for detection
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(chaseRange.transform.position, chaseRangeRadius);
        //for attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRange.transform.position, attackRangeRadius);
    }

    public bool PlayerAttackZoneDetection()
    {
        return Physics2D.OverlapCircle(attackRange.transform.position, attackRangeRadius, target);
    }
}
