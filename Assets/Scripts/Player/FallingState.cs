using UnityEngine;

public class FallingState : BaseState
{
    [SerializeField] float airMovementSpeed;
    string FallingParameterName = "Falling";
    int FallingParameterID;
    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(airMovementSpeed * baseInputControls.horizontalInput, basePhysics.rigidbody.linearVelocityY);
        player.FlipCharacter();
    }

    public override void Initialize()
    {
        base.Initialize();
        FallingParameterID = Animator.StringToHash(FallingParameterName);
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(FallingParameterID, true);
    }

    public override void OnExit(PlayerStateMachine state)
    {
        base.OnExit(state);
        baseAnimator.SetBool(FallingParameterID, false);
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        base.ProcessAbility(state);
        if (basePhysics.isGrounded() && baseInputControls.horizontalInput==0)
        {
            state.ChangeState(state.idle);
        }
        if (basePhysics.isGrounded() && baseInputControls.horizontalInput != 0)
        {
            state.ChangeState(state.walk);
        }
    }
}
