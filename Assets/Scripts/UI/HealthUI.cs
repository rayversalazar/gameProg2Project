using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image healthBarImage;
    [SerializeField] Sprite[] healthFrames;
    [SerializeField] Animator animator;
    int OneHpAnimation;
    int HealingAnimation;
    private void Start()
    {
        OneHpAnimation = Animator.StringToHash("OneHp");
        HealingAnimation = Animator.StringToHash("Healing");
    }
    public void UpdateHealthBar(int currentHP, int maxHP)
    {

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
       
        if (currentHP <= 1)
        {   
            animator.SetBool(OneHpAnimation, true);
            animator.enabled = true;
            
            return;
        } else
        {
            animator.enabled = false;
            animator.SetBool(OneHpAnimation, false);
        }
         healthBarImage.sprite = healthFrames[currentHP];
    }

    public void HealingHealthBar(bool animationSwitch)
    {
        animator.Play(HealingAnimation, 0, 0f);
        animator.SetBool(HealingAnimation, animationSwitch);
        
        animator.enabled = animationSwitch;
    }
    public void refreshUI(int currentHP)
    {
        if (currentHP <= 1)
        {
            animator.SetBool(OneHpAnimation, true);
            animator.enabled = true;

            return;
        }
        else
        {
            animator.enabled = false;
            animator.SetBool(OneHpAnimation, false);
        }
        healthBarImage.sprite = healthFrames[currentHP];
    }
}
