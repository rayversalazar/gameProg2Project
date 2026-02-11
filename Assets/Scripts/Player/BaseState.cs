using UnityEngine;
using UnityEngine.InputSystem;
//base class or template of the various player state and abilities
public abstract class BaseState : MonoBehaviour
{
    protected Player player;

    protected PlayerPhysics basePhysics;
    protected Animator baseAnimator;
    protected PlayerInputControls baseInputControls;
    protected StateCooldown baseCooldown;
    protected SpriteRenderer baseSpriteRenderer;
    protected GameObject baseHitbox;
    protected GameObject baseHurtbox;

    private void Awake()
    {
        Initialize();
    }
    public virtual void Initialize()
    {
        player = GetComponent<Player>();
        basePhysics = player.playerPhysics;
        baseAnimator = player.animator;
        baseInputControls = player.playerInputControls;
        baseCooldown = player.stateCooldown;
        baseSpriteRenderer = player.spriteRenderer;
        baseHitbox = player.hitbox;
        baseHurtbox = player.hurtbox;
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
        Debug.Log("Entered "+ state.currentState +" state.");
    }
    public virtual void OnExit(PlayerStateMachine state)
    {
        //executes before transitioning to the new state
    }

}
