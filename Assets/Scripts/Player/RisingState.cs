using UnityEditor;
using UnityEngine;

public class RisingState : BaseState

{
    [SerializeField] float airMovementSpeed;
    [SerializeField] float minimumPressTime;
    string RisingParameterName = "Rising";
    int RisingParameterID;
    float time;
    public bool risingOnJumpPress = true;//just in case the rising state is needed for non jumping action like floating on something
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
        time = minimumPressTime;
        base.OnEnter(state);
        baseAnimator.SetBool(RisingParameterID, true);
    }

    public override void OnExit(PlayerStateMachine state)
    {
        baseAnimator.SetBool(RisingParameterID, false);
        risingOnJumpPress = true; //back to default value

    }

    public override void ProcessAbility(PlayerStateMachine state)
    {
        if (risingOnJumpPress)
        {
            time -= Time.deltaTime;
            if (baseInputControls.jumpInput == 0 && time <= 0)
            {
                basePhysics.rigidbody.linearVelocity = Vector2.zero;
            }
        }

        if (basePhysics.rigidbody.linearVelocityY <= 0)
        {
            state.falling.dontJumpAfterRiseState = true;
            state.ChangeState(state.falling);
        }
    }
}
