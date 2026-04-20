using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SoleStateDismantle : SoleBaseState
{
    int animParamCharge;
    int animParamHit;
    [SerializeField] float setChargeTime;
    [SerializeField] float currentChargeTime;
    [SerializeField] float distanceToPlayer;
    [SerializeField] GameObject hitbox;
    bool isFinished;
    public override void FixedProcessAbility(SoleStateMachine state)
    {
        base.FixedProcessAbility(state);
        if (currentChargeTime > 0)
        {
            currentChargeTime -= Time.fixedDeltaTime;
        }
    }

    public override void OnEnter(SoleStateMachine state)
    {
        base.OnEnter(state);
        soleAnimator.SetBool(animParamCharge, true);
        currentChargeTime = setChargeTime;

    }

    public override void OnExit(SoleStateMachine state)
    {
        base.OnExit(state); 
        soleAnimator.SetBool(animParamHit, false);
        isFinished = false;
    }

    public override void ProcessAbility(SoleStateMachine state)
    {
        if (currentChargeTime <= 0) SwitchAnimation();
        if (isFinished) state.ChangeState(state.soleIdle);
    }
    public void StartSlash()
    {
        
        transform.position = new Vector3
            (solePhysics.playerPosition.transform.position.x + (distanceToPlayer * solePhysics.PlayerDirectionX()), transform.position.y);
        OpenHitboxSlash();
        sole.soleFlip();
    }

    public void EndSlash()
    {
        CloseHitboxSlash();
        isFinished = true;

    }
    public void OpenHitboxSlash()
    {
        hitbox.layer = LayerMask.NameToLayer("Enemy Hit Box");
    }
    public void CloseHitboxSlash()
    {
        hitbox.layer = 0;
    }
    public void SwitchAnimation()
    {
        soleAnimator.SetBool(animParamCharge, false);
        soleAnimator.SetBool(animParamHit, true);
    }

    protected override void Initialize()
    {
        base.Initialize();
        animParamCharge = Animator.StringToHash("DismantleCharge");
        animParamHit = Animator.StringToHash("DismantleHit");
    }
}
