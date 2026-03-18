using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, overlay;
    public Animator playerAnimator;

    private PlayerControls controls;
    private bool isPaused = false;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Pause.performed += ctx => TogglePause();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        overlay.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        controls.Player.Movement.Disable();
        controls.Player.Jump.Disable();
        controls.Player.Attack.Disable();
        controls.Player.Dash.Disable();

        if (playerAnimator != null)
            playerAnimator.speed = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        overlay.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        controls.Player.Movement.Enable();
        controls.Player.Jump.Enable();
        controls.Player.Attack.Enable();
        controls.Player.Dash.Enable();

        if (playerAnimator != null)
            playerAnimator.speed = 1f;

        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}