using UnityEngine;

public class KnockbackState : BaseState
{
    [SerializeField] float knockbackForceX;
    [SerializeField] float knockbackForceY;
    [SerializeField] float knockbackDuration;
    float time;
    public int knockbackDirection;
    public override void Initialize()
    {
        base.Initialize();
      
    }
    public override void OnEnter(PlayerStateMachine state)
    {
        time = knockbackDuration;

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
            state.ChangeState(state.idle);
        }

    }
}