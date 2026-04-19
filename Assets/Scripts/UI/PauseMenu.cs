using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public GameObject healthBar;
    private PlayerControls controls;
    public PlayerInputControls playerInput;
    private void Awake()
    {
        Debug.Log("PauseMenu: Awake - Initializing controls");

        controls = new PlayerControls();

        controls.Player.PauseGame.performed += ctx =>
        {
            Debug.Log("PauseMenu: Escape key pressed!");
            TogglePause();
        };
    }

    private void OnEnable()
    {
        Debug.Log("PauseMenu: Enabled input system");
        controls.Enable();
    }

    private void OnDisable()
    {
        Debug.Log("PauseMenu: Disabled input system");
        controls.Disable();
    }

    void TogglePause()
    {
        bool isActive = container.activeSelf;

        Debug.Log("PauseMenu: TogglePause called. Current state = " + isActive);

        container.SetActive(true);

        if (isActive)
        {
            Debug.Log("PauseMenu: Resuming game");
            Time.timeScale = 1f;
            container.SetActive(false);
            playerInput.inputs.Player.Enable();
            healthBar.SetActive(true);
        }
        else
        {
            Debug.Log("PauseMenu: Pausing game");
            Time.timeScale = 0f;
            playerInput.inputs.Player.Disable();
            healthBar.SetActive(false);
        }
    }

    public void ResumeButton()
    {
        Debug.Log("PauseMenu: Resume button clicked");

        container.SetActive(false);
        Time.timeScale = 1f;
        playerInput.inputs.Player.Enable();
        healthBar.SetActive(true);
    }

    public void MainMenuButton()
    {
        Debug.Log("PauseMenu: Loading Main Menu");

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}