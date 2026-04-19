using UnityEngine;

public class HealingState : BaseState
{
    int healingAnimParameter;
    bool healFinished;
    bool healCanceled;
    public override void Initialize()
    {
        base.Initialize();
        healingAnimParameter = Animator.StringToHash("Healing");
    }
    private void OnEnable()
    {
       
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        baseAnimator.SetBool(healingAnimParameter, true);
        baseAnimator.Play(healingAnimParameter, 0, 0f);

    }
    public override void OnExit(PlayerStateMachine state)
    {
        healFinished = false;
        baseAnimator.SetBool(healingAnimParameter, false);
        baseHealthUI.refreshUI(player.currentHP);
    }
    public override void ProcessAbility(PlayerStateMachine state)
    {
        
        if (healFinished)
        {
            state.ChangeState(state.idle);
        }
    }
    public void StartHeal()
    { 
       baseHealthUI.HealingHealthBar(true);
    }
    public void FinishedHeal()
    {
        baseHealthUI.HealingHealthBar(false);
        player.HealHP(8);
        healFinished = true;
        baseAnimator.SetBool(healingAnimParameter, false);
    }

}
