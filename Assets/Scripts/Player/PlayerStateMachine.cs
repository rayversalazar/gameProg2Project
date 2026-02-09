using UnityEngine;
//handles the changing state logic and container for the current state of the player
public class PlayerStateMachine : MonoBehaviour
{
    public BaseState currentState;
    public IdleState idle;
    public WalkState walk;
    public JumpState jump;
    public RisingState rising;
    public FallingState falling;
    public KnockbackState knockback;
    private void Start()
    {
        //default state
        currentState = idle;
        currentState.OnEnter(this);
    }
    private void Update()
    {
        
        currentState.ProcessAbility(this);
    }
    private void FixedUpdate()
    {
        currentState.FixedProcessAbility(this);
    }
    public void ChangeState(BaseState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }
}
