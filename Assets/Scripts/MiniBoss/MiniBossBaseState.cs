using UnityEngine;

public class MiniBossBaseState : MonoBehaviour
{
    protected MiniBoss miniBoss;
    private void Awake()
    {
        Initialize();
    }
    protected virtual void Initialize()
    {
        miniBoss = GetComponent<MiniBoss>();
    }
    public virtual void ProcessAbility(MiniBossStateMachine state)
    {
        //needs to be in the update method
    }
    public virtual void FixedProcessAbility(MiniBossStateMachine state)
    {
        //needs to be in the fixed update method
    }
    public virtual void OnEnter(MiniBossStateMachine state)
    {
        Debug.Log("Enemy entered " + state.currentState + " state.");
    }
    public virtual void OnExit(MiniBossStateMachine state)
    {
        //executes before transitioning to the new state
    }
}
