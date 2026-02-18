using UnityEngine;

public class MiniBossPhysics : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] Transform chaseRange;
    [SerializeField] float chaseRangeRadius;
    [SerializeField] Transform attackRange;
    [SerializeField] float attackRangeRadius;
    [SerializeField] LayerMask target;
    [SerializeField] Transform playerPosition;

    public bool PlayerDetectionZone()
    {
        return Physics2D.OverlapCircle(chaseRange.position, chaseRangeRadius, target);
    }
    public float PlayerPositionX()
    {
        return playerPosition.position.x > transform.position.x ? 1f : -1f;
    }
    private void OnDrawGizmos()
    {
        //for detection
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(chaseRange.position, chaseRangeRadius);
        //for attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRange.position, attackRangeRadius);
    }

    public bool PlayerAttackZoneDetection()
    {
        return Physics2D.OverlapCircle(attackRange.position, attackRangeRadius, target);
    }
}
