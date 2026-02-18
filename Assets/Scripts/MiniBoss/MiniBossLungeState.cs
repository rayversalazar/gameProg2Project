using UnityEngine;

public class MiniBossLungeState : MiniBossBaseState
{
    public Vector2 lungeForce;
    public float setLungeDuration;
    public float currentLungeDuratiion;
    int animationParameterId = Animator.StringToHash("Lunge");
    public override void ProcessAbility(MiniBossStateMachine state)
    {
        if (currentLungeDuratiion > 0)
        {
            currentLungeDuratiion -= Time.deltaTime;
            return;
        }
        baseAnimator.SetBool(animationParameterId, false);
        state.ChangeState(state.rest);

    }


    public override void OnEnter(MiniBossStateMachine state)
    {
        base.OnEnter(state);
        currentLungeDuratiion = setLungeDuration;
        basePhysics.rigidbody.AddForce(new Vector2(lungeForce.x * basePhysics.PlayerPositionX(), lungeForce.y), ForceMode2D.Impulse);
        baseHitbox.layer = LayerMask.NameToLayer("Enemy Hit Box");
        baseAnimator.SetBool(animationParameterId, true);

    }

    public override void OnExit(MiniBossStateMachine state)
    {
        baseHitbox.layer = 0;
        baseAnimator.SetBool(animationParameterId, false);
    }


}
