using UnityEngine;

public class MiniBossChaseState : MiniBossBaseState
{
    [SerializeField] float chaseSpeed;
    int animationParameterId = Animator.StringToHash("Chase");

    public override void FixedProcessAbility(MiniBossStateMachine state)
    {
        if (basePhysics.PlayerAttackZoneDetection()) 
        {
            basePhysics.rigidbody.linearVelocity = Vector2.zero;
            state.ChangeState(state.attack);
            return;
        }

        basePhysics.rigidbody.linearVelocity= new Vector2(chaseSpeed * basePhysics.PlayerPositionX(), basePhysics.rigidbody.linearVelocityY);
    }

    public override void OnEnter(MiniBossStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(animationParameterId, true);
    }

    public override void OnExit(MiniBossStateMachine state)
    {
    int animationParameterId = Animator.StringToHash("Chase");
        baseAnimator.SetBool(animationParameterId, false);
    }

    public override void ProcessAbility(MiniBossStateMachine state)
    {
        if (!basePhysics.PlayerDetectionZone()) state.ChangeState(state.idle);
        miniBoss.EnemyFlip();
    }
}
