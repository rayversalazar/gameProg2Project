using Unity.VisualScripting;
using UnityEngine;

public class FallingState : BaseState
{
    [SerializeField] float airMovementSpeed;
    [SerializeField] float gravityMultiplier = 1f ;
    [SerializeField] float peakJumpTime;
    [SerializeField] float coyoteTimeJump;
    float defaultGravity;
    bool gravitySwitch;
    public bool AfterRiseState = false;//fix for double jump in coyote time
    string FallingParameterName = "Falling";
    int FallingParameterID;
    float time;
    float currentPeakJumpTime;
    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(airMovementSpeed * baseInputControls.horizontalInput, basePhysics.rigidbody.linearVelocityY);
        player.FlipCharacter();
    }

    public override void Initialize()
    {
        base.Initialize();
        FallingParameterID = Animator.StringToHash(FallingParameterName);
        defaultGravity = basePhysics.rigidbody.gravityScale;

    }

    public override void OnEnter(PlayerStateMachine state)
    {
        time = coyoteTimeJump;
        base.OnEnter(state);
        baseAnimator.SetBool(FallingParameterID, true);
        
        currentPeakJumpTime = peakJumpTime;
    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseAnimator.SetBool(FallingParameterID, false);
        AfterRiseState = false;
        basePhysics.rigidbody.gravityScale = defaultGravity;

    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        time -= Time.deltaTime;
        
        if (currentPeakJumpTime > 0)
        {
            currentPeakJumpTime -= Time.deltaTime;
        } 
        if (currentPeakJumpTime <=0)
        {
            basePhysics.rigidbody.gravityScale = defaultGravity * gravityMultiplier;
        }
        if (time > 0 && baseInputControls.jump.triggered && !AfterRiseState)
        {
            state.ChangeState(state.jump);
        }
        if (basePhysics.isGrounded() && baseInputControls.horizontalInput==0)
        {
            state.jump.JumpReset();
            state.ChangeState(state.idle);
        }
        if (basePhysics.isGrounded() && baseInputControls.horizontalInput != 0)
        {
            state.jump.JumpReset();
            state.ChangeState(state.walk);
        }
        if (state.jump.currentJumpCount > 0 && baseInputControls.jump.triggered && time<=0)
        {
            state.ChangeState(state.jump);
        }
        if (basePhysics.isWallDetected() && baseInputControls.horizontalInput != 0 && !basePhysics.isGrounded())
        {
            state.ChangeState(state.wallClimb);
        }
        if (baseInputControls.attack.triggered)
        {
            state.ChangeState(state.attack);
        }
        
    }
}
