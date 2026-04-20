using UnityEngine;

public class SolePhysics : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D soleRB;
    public Transform playerDetection;
    public float playerDetectionRadius;
    public LayerMask target;
    public Transform playerPosition;
    void Start()
    {
        
    }
    public bool PlayerDetected()
    {
        Collider2D player = Physics2D.OverlapCircle(new Vector2(playerDetection.transform.position.x, playerDetection.transform.position.y), playerDetectionRadius, target);
        if (player != null) {
            playerPosition = player.transform;
            return true; 
        }
        else return false;
    }
    public float PlayerDirectionX()
    {
        if (PlayerDetected())
            return playerPosition.position.x > transform.position.x ? 1f : -1f;
        return 0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, playerDetectionRadius);
        Gizmos.color = Color.red;
    }
}
