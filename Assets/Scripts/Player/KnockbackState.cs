using UnityEngine;

public class KnockbackState : BaseState
{
    [SerializeField] float knockbackForceX;
    [SerializeField] float knockbackForceY;
    [SerializeField] float knockbackStateDuration;
    [SerializeField] float time;
    int animParameterId = Animator.StringToHash("Knockback");
    public int knockbackDirection;
    public override void Initialize()
    {
        base.Initialize();
      
    }
    public override void OnEnter(PlayerStateMachine state)
    {
        player.hasBeenHit = true;
        baseAnimator.SetBool(animParameterId, true);
        time = knockbackStateDuration;

        basePhysics.rigidbody.linearVelocity = Vector2.zero;

        basePhysics.rigidbody.AddForce(new Vector2(knockbackDirection*knockbackForceX, knockbackForceY), ForceMode2D.Impulse);


    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if(basePhysics.isGrounded())
            state.ChangeState(state.idle);
            
            else state.ChangeState(state.rising);
        }

    }
    public override void OnExit(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        baseAnimator.SetBool(animParameterId, false);
    }
}