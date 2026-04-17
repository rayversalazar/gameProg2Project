using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager1 : MonoBehaviour
{
    public GameObject AchievementPanel,SettingsPanel ;

    public void Play()
    {
        SceneManager.LoadScene("6");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    public void OpenSettingsMenu()
    {
        SettingsPanel.SetActive(true);
        AchievementPanel.transform.SetAsLastSibling();
    }
    public void CloseSettingsMenu()
    {
        SettingsPanel.SetActive(false);
    }
    public void OpenAchievementsMenu()
    {
        AchievementPanel.SetActive(true);
        AchievementPanel.transform.SetAsLastSibling();
    }
    public void CloseAchievementMenu()
    {
        AchievementPanel.SetActive(false);
    }
  




}
