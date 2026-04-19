using System.Collections;
using UnityEngine;

public class WakeUpState : BaseState
{
    int WakeUpAnimParameter = Animator.StringToHash("WakeUp");
    bool lastFrame;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnEnter(PlayerStateMachine state)
    {
        base.OnEnter(state);
        StartCoroutine(WakingUp());
    }

    public override void OnExit(PlayerStateMachine state)
    {
        base.OnExit(state);
        baseAnimator.SetBool(WakeUpAnimParameter, false);
        lastFrame = false;

    }
    public void LastFrame()
    {
        lastFrame = true;
    }
    public override void ProcessAbility(PlayerStateMachine state)
    {
       if (lastFrame)
        {
            state.ChangeState(state.idle);
        }
    }
    public IEnumerator WakingUp()
    {
        player.fadescreen.blackout();
        basePhysics.rigidbody.linearVelocity = Vector2.zero;
        transform.position = player.currentSpawnPoint;
        yield return new WaitForSeconds(0.3f);
        player.fadescreen.Fade(0);
        baseAnimator.SetBool(WakeUpAnimParameter, true);
        
        
    }
}
