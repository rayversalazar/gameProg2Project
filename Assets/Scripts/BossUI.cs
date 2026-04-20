using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private Image boss1HP;
    [SerializeField] private Image boss2HP;

    private MiniBossStateMachine boss1;
    private MiniBossStateMachine boss2;

    public void SetBosses(MiniBossStateMachine b1, MiniBossStateMachine b2)
    {
        boss1 = b1;
        boss2 = b2;

        container.SetActive(true);
    }

    private void Update()
    {
        if (boss1 != null)
            boss1HP.fillAmount = boss1.currentHP / boss1.maxHP;

        if (boss2 != null)
            boss2HP.fillAmount = boss2.currentHP / boss2.maxHP;
    }

    public void Hide()
    {
        container.SetActive(false);
    }
}