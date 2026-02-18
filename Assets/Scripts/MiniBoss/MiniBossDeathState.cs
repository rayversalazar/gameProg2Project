using UnityEngine;

public class MiniBossDeathState : MiniBossBaseState
{
    [SerializeField] float fadeSpeed;
    Color currentColor;
    public override void FixedProcessAbility(MiniBossStateMachine state)
    {
        base.FixedProcessAbility(state);
    }

    public override void OnEnter(MiniBossStateMachine state)
    {
        baseHurtBox.layer = 0;
    }

    public override void OnExit(MiniBossStateMachine state)
    {
        base.OnExit(state);
    }

    public override void ProcessAbility(MiniBossStateMachine state)
    {
        currentColor = baseSpriteRenderer.color;
        currentColor.a -= fadeSpeed * Time.deltaTime;
        baseSpriteRenderer.color = currentColor;
        if (currentColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
