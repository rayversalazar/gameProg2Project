using UnityEngine;

public abstract class SoleBaseState : MonoBehaviour
{
    protected Sole sole;

    protected Animator soleAnimator;
    protected SolePhysics solePhysics;
    void Awake()
    {
        Initialize();
    }
    protected virtual void Initialize()
    {
        sole = GetComponent<Sole>();
        soleAnimator = sole.animator;
        solePhysics = sole.physics;

    }
    public virtual void ProcessAbility(SoleStateMachine state)
    {
        //needs to be in the update method
    }
    public virtual void FixedProcessAbility(SoleStateMachine state)
    {
        //needs to be in the fixed update method
    }
    public virtual void OnEnter(SoleStateMachine state)
    {
        
    }
    public virtual void OnExit(SoleStateMachine state)
    {
        //executes before transitioning to the new state
    }
}
