using UnityEngine;

public class RisingState : BaseState

{
    [SerializeField] float airMovementSpeed;
    string RisingParameterName = "Rising";
    int RisingParameterID;
    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(airMovementSpeed * baseInputControls.horizontalInput, basePhysics.rigidbody.linearVelocityY);
        player.FlipCharacter();
    }

    public override void Initialize()
    {
        base.Initialize();
        RisingParameterID = Animator.StringToHash(RisingParameterName);
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(RisingParameterID, true);
    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseAnimator.SetBool(RisingParameterID, false);
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        if (basePhysics.rigidbody.linearVelocityY <= 0)
        {
            state.ChangeState(state.falling);
        }
    }
}
