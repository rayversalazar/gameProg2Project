using UnityEngine;
//base class or template of the various player state and abilities
public abstract class BaseState : MonoBehaviour
{
    public PlayerStates.states state;
    protected Player player;

    protected PlayerPhysics basePhysics;
    protected Animator baseAnimator;
    protected PlayerInputControls baseInputControls;

    private void Start()
    {
        Initialize();
    }
    public virtual void Initialize()
    {
        player = GetComponent<Player>();
        basePhysics = player.playerPhysics;
        baseAnimator = player.animator;
        baseInputControls = player.playerInputControls;
    }
    public virtual void ProcessAbility(PlayerStateMachine state)
    {
        //needs to be in the update method
    }
    public virtual void FixedProcessAbility(PlayerStateMachine state)
    {
        //needs to be in the fixed update method
    }
    public virtual void OnEnter(PlayerStateMachine state)
    {
        Debug.Log("Entered "+ this.state +" state.");
    }
    public virtual void OnExit(PlayerStateMachine state)
    {
        //executes before transitioning to the new state
    }

}
