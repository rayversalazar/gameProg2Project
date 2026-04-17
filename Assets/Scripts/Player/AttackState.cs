using UnityEngine;

public class AttackState : BaseState
{
    bool attackFinished = false;
    bool attackSwitch;
    [SerializeField] float attackSpeed = 1f;
    [SerializeField] float defaultAnimationSpeed;
    string attackAnimation1 = "Attack1";
    string attackAnimation2 = "Attack2";
    int attack1parameter;
    int attack2parameter;
    int animParameterId;
    public override void Initialize()
    {
        base.Initialize();
        attack1parameter = Animator.StringToHash(attackAnimation1);
        attack2parameter = Animator.StringToHash(attackAnimation2);
        animParameterId = attack1parameter;
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        defaultAnimationSpeed = baseAnimator.speed;
        baseAnimator.SetBool(animParameterId, true);
    }

    public void StartAttack()
    { 
        baseAnimator.speed = attackSpeed;
        baseHitbox.layer = LayerMask.NameToLayer("Player Hit Box");
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
    }
    public void EndAttack()
    {
        baseHitbox.layer = 0;
        attackFinished = true;
    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseAnimator.SetBool(animParameterId, false);
        attackSwitch = !attackSwitch;
        animParameterId = attackSwitch == true ? attack1parameter : attack2parameter;
        baseHitbox.layer = 0;
        baseAnimator.speed = defaultAnimationSpeed;
        attackFinished = false;
    }


    public override void ProcessAbility(PlayerStateMachine state)
    {
        if (attackFinished && basePhysics.isGrounded())
        {
            state.ChangeState(state.idle);
        } else 
        if (attackFinished &&!basePhysics.isGrounded())
        {
            state.ChangeState(state.falling);
        }
        if (state.jump.currentJumpCount > 0 && baseInputControls.jump.triggered)
        {
            state.ChangeState(state.jump);
        }
    }
}
