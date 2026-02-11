using UnityEngine;

public class DashState : BaseState
{
    [SerializeField] float dashSpeed;
    [SerializeField] float setDashDuration;
    float dashDuration;
    float defaultGravityScale;
    float direction;
    int animParameterID = Animator.StringToHash("Dash");
    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(dashSpeed * direction, 0f);

    }
    public override void Initialize()
    {
        base.Initialize();
        defaultGravityScale = basePhysics.rigidbody.gravityScale;
    }
    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        direction = player.facingRight ? -1 : 1;
        dashDuration = setDashDuration;
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        basePhysics.rigidbody.gravityScale = 0;
        ImmunityWhileDash(true);
        baseSpriteRenderer.color = Color.yellow;
        baseAnimator.SetBool(animParameterID, true);


    }

    public override void OnExit(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        basePhysics.rigidbody.gravityScale = defaultGravityScale;
        ImmunityWhileDash(false);
        baseSpriteRenderer.color = Color.white;
        baseAnimator.SetBool(animParameterID, false);
        baseCooldown.startDashCooldown();
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        dashDuration -= Time.deltaTime;
        if (dashDuration<=0)
        {
            if (basePhysics.isGrounded() && baseInputControls.horizontalInput != 0)
            {
                state.ChangeState(state.walk);
            }else {
                state.ChangeState(state.idle);
            }
        }
    }
    void ImmunityWhileDash(bool setImmunity)
    {
        Transform hurtbox = transform.Find("HurtBox");
        if (setImmunity == true)
        {
            hurtbox.gameObject.layer = LayerMask.NameToLayer("Player Immunity");
        } else
        {
            hurtbox.gameObject.layer = LayerMask.NameToLayer("Player Hurt Box");
        }
    }
}
