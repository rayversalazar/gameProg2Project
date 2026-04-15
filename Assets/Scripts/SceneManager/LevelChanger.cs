using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelConnection connection;
    [SerializeField] private string levelToLoad;
    [SerializeField] private Transform playerSpawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnPlayer());
    }

    private IEnumerator SpawnPlayer()
    {
        yield return null;

        if (LevelConnection.ActiveConnection == null) yield break;

        if (connection == LevelConnection.ActiveConnection)
        {
            Player player = FindObjectOfType<Player>();

            if (player != null)
            {
                player.transform.position = playerSpawnPoint.position;

                // Re-enable input and movement after spawn (if they were disabled)
                var pic = player.playerInputControls ?? player.GetComponent<PlayerInputControls>();
                if (pic != null)
                {
                    pic.enabled = true;
                    if (pic.inputs != null)
                        pic.inputs.Enable();
                }

                if (player.playerPhysics != null)
                    player.playerPhysics.enabled = true;

                player.enabled = true;

                CinemachineVirtualCamera cam = FindObjectOfType<CinemachineVirtualCamera>();
                if (cam != null)
                {
                    cam.Follow = player.transform;
                    cam.LookAt = player.transform;
                }

                Debug.Log("Player spawned correctly!");
                LevelConnection.ActiveConnection = null;
            }
            else
            {
                Debug.LogError("Player not found in scene!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            // Unbind
            var pic = player.playerInputControls ?? player.GetComponent<PlayerInputControls>();
            if (pic != null)
            {
                // Explicitly disable the action maps and the component
                if (pic.inputs != null)
                    pic.inputs.Disable();
                pic.enabled = false;
            }

            // If you also use a PlayerInput component in some setups, disable it too
            var playerInput = player.GetComponent<PlayerInput>();
            if (playerInput != null)
                playerInput.enabled = false;

            // Optionally disable player logic to be extra safe
            if (player.playerPhysics != null)
                player.playerPhysics.enabled = false;
            player.enabled = false;

            // Stop movement (prevents sliding)
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            StartCoroutine(TransitionToScene());
        }
    }

    private IEnumerator TransitionToScene()
    {
        Debug.Log("Scene changing...");

        // Fade out
        if (SceneFader.Instance != null)
            yield return SceneFader.Instance.StartCoroutine(SceneFader.Instance.FadeOut());

        // Save which door was used
        LevelConnection.ActiveConnection = connection;

        // Load scene
        SceneManager.LoadScene(levelToLoad);

        // Wait 1 frame
        yield return null;

        // 🔥 Hold black screen
        yield return new WaitForSeconds(1f);

        // Fade in
        if (SceneFader.Instance != null)
            yield return SceneFader.Instance.StartCoroutine(SceneFader.Instance.FadeIn());
    }
}