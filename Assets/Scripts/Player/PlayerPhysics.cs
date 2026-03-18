using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] Player player;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckerPosition;
    [SerializeField] Vector2 groundCheckerSize;
    [SerializeField] float castDistance = 0.05f;
    [SerializeField] Transform wallCheckerPosition;
    [SerializeField] float wallCheckCastDistance = 0.05f;
    public bool wallDetected;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wallDetected = isWallDetected();
    }
    public bool isWallDetected()
    {
        Vector2 direction = !player.facingRight ? Vector2.right : Vector2.left;
        RaycastHit2D wallDetected = Physics2D.Raycast(wallCheckerPosition.position, direction, wallCheckCastDistance,groundLayer);
        return wallDetected;
    }
    public bool isGrounded()
    {
        RaycastHit2D hitGround = Physics2D.BoxCast(groundCheckerPosition.position, groundCheckerSize, 0f, Vector2.zero, castDistance, groundLayer);
        return hitGround;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheckerPosition.position, groundCheckerSize);

        Gizmos.color = Color.red;
        Vector2 direction = !player.facingRight ? Vector2.right : Vector2.left;
        Gizmos.DrawRay(wallCheckerPosition.position, direction * wallCheckCastDistance);
    }
}
