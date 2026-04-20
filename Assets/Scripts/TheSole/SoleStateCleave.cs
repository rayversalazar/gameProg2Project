using UnityEngine;

public class SoleStateCleave : SoleBaseState
{
    int animParamThrow;
    int animParamDash;
    int animParamSheath;
    [SerializeField] float dashSpeed;
    [SerializeField] float setDashDuration;
    [SerializeField] float currentDashDuration;
    float direction;
    float defaultGravity;

    bool isFinished;
    bool isDashing;

    public override void FixedProcessAbility(SoleStateMachine state)
    {
        base.FixedProcessAbility(state);
        
    }

    public override void OnEnter(SoleStateMachine state)
    {
        base.OnEnter(state);
        soleAnimator.SetBool(animParamThrow, true);
        solePhysics.soleRB.gravityScale = 0;
        currentDashDuration = setDashDuration;
        sole.soleFlip();
        isFinished = false;
        isDashing = false;
    }

    public override void OnExit(SoleStateMachine state)
    {
        base.OnExit(state);
        solePhysics.soleRB.gravityScale = defaultGravity;
        isFinished = false;
        soleAnimator.SetBool(animParamThrow, false);
        soleAnimator.SetBool(animParamDash, false);
        soleAnimator.SetBool(animParamSheath, false);
    }

    protected override void Initialize()
    {
        base.Initialize();
        animParamThrow = Animator.StringToHash("Throw");
        animParamDash = Animator.StringToHash("Dash");
        animParamSheath = Animator.StringToHash("Sheath");
        defaultGravity = solePhysics.soleRB.gravityScale;
    }

    public override void ProcessAbility(SoleStateMachine state)
    {
        base.ProcessAbility(state);
        if (isFinished)
        {
            state.ChangeState(state.soleIdle);
            return;
        }
        if (isDashing)
        {
            if (currentDashDuration > 0)
            {
                currentDashDuration -= Time.fixedDeltaTime;
            }
            else
            {
                isDashing = false;

                solePhysics.soleRB.linearVelocity = Vector2.zero;

                soleAnimator.SetBool(animParamDash, false);
                soleAnimator.SetBool(animParamSheath, true);
            }
        }
    }
    public void EndThrow()

    {
        soleAnimator.SetBool(animParamThrow, false);
        soleAnimator.SetBool(animParamDash, true);
        direction = solePhysics.PlayerDirectionX();
    }

    public void Dash()
    {
        sole.soleFlip();

        isDashing = true;

        
        solePhysics.soleRB.AddForce(new Vector2(direction * dashSpeed, 0f), ForceMode2D.Impulse);
    }

    public void Sheath()
    {
    }

    public void EndCleave()
    {
        isFinished = true;
        soleAnimator.SetBool(animParamSheath, false);
    }
}