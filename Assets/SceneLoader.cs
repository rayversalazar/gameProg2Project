using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // IMPORTANT: reset time before leaving

        SceneManager.LoadScene("MainMenu");
    }
}