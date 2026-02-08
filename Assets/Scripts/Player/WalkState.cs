using UnityEngine;

public class WalkState : BaseState
{
    [SerializeField] float movementSpeed;
    private string walkParameterName = "Walk";
    private int walkParameterID;

    public override void FixedProcessAbility(PlayerStateMachine state)
    {
        Walk();
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(walkParameterID, true);
    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseAnimator.SetBool(walkParameterID, false);
        basePhysics.rigidbody.linearVelocityX = 0;
    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        //transitioning from walk to idle
        if (baseInputControls.horizontalInput == 0 && basePhysics.isGrounded())
        {
            state.ChangeState(state.idle);
        }
        //transitioning from walk to jump
        if (basePhysics.isGrounded() && baseInputControls.jumpActionRef.action.triggered)
        {
            state.ChangeState(state.jump);
        }
        //transitioning from walk to falling
        if (!basePhysics.isGrounded() && basePhysics.rigidbody.linearVelocityY<0)
        {
            state.ChangeState(state.falling);
        }
    }
    public override void Initialize()
    {
        base.Initialize();
        walkParameterID = Animator.StringToHash(walkParameterName);
    }
    void Walk()
    {
        basePhysics.rigidbody.linearVelocity = new Vector2(movementSpeed * baseInputControls.horizontalInput, basePhysics.rigidbody.linearVelocityY);
        player.FlipCharacter();
    }
}
