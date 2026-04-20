using UnityEngine;

public class SoleStateMachine : MonoBehaviour
{
    public SoleBaseState currentState;

    public SoleStateIdle soleIdle;
    public SoleStateDismantle soleDismantle;
    public SoleStateCleave soleCleave;
    public SoleStateDeath soleDeath;

    void Start()
    {
        Debug.Log("i was here");
        currentState = soleIdle;
        currentState.OnEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.ProcessAbility(this);
    }
    private void FixedUpdate()
    {
        currentState.FixedProcessAbility(this);
    }
    
    public void ChangeState(SoleBaseState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);

    }
}
