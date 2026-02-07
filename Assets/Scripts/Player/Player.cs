using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerPhysics playerPhysics;
    public PlayerInputControls playerInputControls;
    public Animator animator;
    public PlayerStateMachine stateMachine;
    private bool facingRight = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlipCharacter()
    {
        if (playerInputControls.horizontalInput < 0 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;// this is like a switch
        } else if (playerInputControls.horizontalInput  >0 && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = !facingRight;
        }
    }
}
