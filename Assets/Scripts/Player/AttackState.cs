using UnityEngine;

public class AttackState : BaseState
{
    bool isAttacking;
    [SerializeField] float attackSpeed = 1f;
    [SerializeField] float defaultAnimationSpeed;
    string animParameterName = "Attack";

    int animParameterId;
    AnimatorStateInfo animationState;
    public override void Initialize()
    {
        base.Initialize(); 
        animParameterId = Animator.StringToHash(animParameterName);
        animationState = baseAnimator.GetCurrentAnimatorStateInfo(animParameterId);
       
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(animParameterId, true);
        isAttacking = true;
        defaultAnimationSpeed = baseAnimator.speed;
        baseAnimator.speed = attackSpeed;
        baseSoundFX.Play(baseSoundFX.attack);
    }

    public void StartAttack()
    {
        baseHitbox.layer = LayerMask.NameToLayer("Player Hit Box");
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
    }
    public void EndAttack()
    {
        isAttacking = false;
        baseHitbox.layer = 0;
        baseAnimator.speed = defaultAnimationSpeed;
    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseAnimator.SetBool(animParameterId, false);
        baseHitbox.layer = 0;
        baseAnimator.speed = defaultAnimationSpeed;
    }


    public override void ProcessAbility(PlayerStateMachine state)
    {
        if (!isAttacking)
        {
            state.ChangeState(state.idle);
        }
        if (state.jump.currentAdditionalJumpCount > 0 && baseInputControls.jump.triggered)
        {
            state.jump.currentAdditionalJumpCount--;
            state.ChangeState(state.jump);
        }
    }
}
