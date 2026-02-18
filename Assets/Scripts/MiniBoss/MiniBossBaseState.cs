using UnityEngine;

public abstract class MiniBossBaseState : MonoBehaviour
{
    protected MiniBoss miniBoss;
    protected MiniBossPhysics basePhysics;
    protected SpriteRenderer baseSpriteRenderer;
    protected GameObject baseHitbox;
    protected GameObject baseHurtBox;
    protected Animator baseAnimator;
    private void Awake()
    {
        Initialize();
    }
    protected virtual void Initialize()
    {
        miniBoss = GetComponent<MiniBoss>();
        basePhysics = miniBoss.miniBossPhysics;
        baseSpriteRenderer = miniBoss.spriteRenderer;
        baseHitbox = miniBoss.hitbox;
        baseAnimator = miniBoss.anim;
        baseHurtBox = miniBoss.hurtbox;
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
