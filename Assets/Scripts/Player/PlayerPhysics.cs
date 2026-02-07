using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    [SerializeField] Transform groundChecker;
    [SerializeField] float groundCheckerRadius;
    [SerializeField] LayerMask groundLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
