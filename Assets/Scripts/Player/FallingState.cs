using UnityEngine;

public class FallingState : BaseState
{
    [SerializeField] float airMovementSpeed;
    [SerializeField] float coyoteTimeJump;
    string FallingParameterName = "Falling";
    int FallingParameterID;
    string landingParameterName = "Land";
    int landingParameterID;

    float time;
    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(airMovementSpeed * baseInputControls.horizontalInput, basePhysics.rigidbody.linearVelocityY);
        player.FlipCharacter();
    }

    public override void Initialize()
    {
        base.Initialize();
        FallingParameterID = Animator.StringToHash(FallingParameterName);
        landingParameterID = Animator.StringToHash(landingParameterName);
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        time = coyoteTimeJump;
        base.OnEnter(state);
        baseAnimator.SetBool(FallingParameterID, true);
    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseAnimator.SetTrigger(landingParameterID);
        baseAnimator.SetBool(FallingParameterID, false);
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        time -= Time.deltaTime;
        if (time>0 && baseInputControls.jumpActionRef.action.triggered)
        {
            state.ChangeState(state.jump);
        }
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
