using UnityEngine;

public class KnockbackState : BaseState
{
    [SerializeField] float knockbackForceX;
    [SerializeField] float knockbackForceY;
    [SerializeField] float knockbackStateDuration;
    [SerializeField] float time;
    public int knockbackDirection;
    public override void Initialize()
    {
        base.Initialize();
      
    }
    public override void OnEnter(PlayerStateMachine state)
    {
        time = knockbackStateDuration;

        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        if (!player.facingRight)
        {
            basePhysics.rigidbody.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Impulse);
            return;
        }

        basePhysics.rigidbody.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Impulse);


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
    }
}