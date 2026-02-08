using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckerPosition;
    [SerializeField] Vector2 groundCheckerSize;
    [SerializeField] float castDistance = 0.05f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
