using UnityEngine;

public class MiniBossStateMachine : MonoBehaviour
{
    public MiniBossBaseState currentState;
    public MiniBossIdleState idle;
    public MiniBossAttackState attack;
    public MiniBossWindUpState windUp;
    public MiniBossLungeState lunge;
    public MiniBossRestState rest;
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

    public void ChangeState(MiniBossBaseState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }
}
