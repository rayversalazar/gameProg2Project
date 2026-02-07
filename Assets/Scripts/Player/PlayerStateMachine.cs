using UnityEngine;
//handles the changing state logic and container for the current state of the player
public class PlayerStateMachine : MonoBehaviour
{
    BaseState currentState;
    public IdleState idle;
    public WalkState walk;
    public JumpState jump;
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
