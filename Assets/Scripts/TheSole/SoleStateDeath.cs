using UnityEngine;

public class SoleStateDeath : SoleBaseState
{
    public SpriteRenderer soleSpriteRenderer;

    [Header("Fade Settings")]
    [SerializeField] float fadeSpeed = 1f; // Higher number = faster fade
    bool isFading;

    public override void OnEnter(SoleStateMachine state)
    {
        base.OnEnter(state);

        isFading = true;
    }

    public override void ProcessAbility(SoleStateMachine state)
    {
        base.ProcessAbility(state);

        if (isFading && soleSpriteRenderer != null)
        {
            // 1. Get the current color of the sprite
            Color currentColor = soleSpriteRenderer.color;

            // 2. Subtract from the alpha channel over time
            currentColor.a -= fadeSpeed * Time.deltaTime;

            // 3. Apply the updated color back to the SpriteRenderer
            soleSpriteRenderer.color = currentColor;

            // 4. Check if the sprite is completely invisible
            if (currentColor.a <= 0)
            {
                currentColor.a = 0;
                soleSpriteRenderer.color = currentColor;
                isFading = false;

                // Clean up: Destroy the entire Enemy GameObject once the fade is complete
                Destroy(gameObject);
            }
        }
    }
}