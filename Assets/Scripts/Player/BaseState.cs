using UnityEngine;
//base class or template of the various player state and abilities
public class BaseState : MonoBehaviour
{
    Player player;

    public virtual void ProcessAbility()
    {
        //needs to be in the update method
    }
    public virtual void FixedProcessAbility()
    {
        //needs to be in the fixed update method
    }
    public virtual void OnEnter()
    {
        //executes right after transitioning from the previous state
    }
    public virtual void OnExit()
    {
        //executes before transitioning to the new state
    }
    public virtual void AnimationState()
    {
        //executes before transitioning to the new state
    }
}
