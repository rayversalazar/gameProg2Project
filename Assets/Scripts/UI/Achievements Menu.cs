using UnityEngine;

public class AchievementsMenu : MonoBehaviour
{
    public GameObject AchievementMenu;
    public void AchievementsButton()
    {
        AchievementMenu.SetActive(true);
    }

    public void CloseAchievementMenu()
    {
        AchievementMenu.SetActive(false);
    }
}
