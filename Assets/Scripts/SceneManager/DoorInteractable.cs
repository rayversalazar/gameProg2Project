using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorInteractable : MonoBehaviour, IInteractible
{
    [Header("Scene")]
    [SerializeField] private string sceneToLoad;

    [Header("UI")]
    [SerializeField] private GameObject interactPrompt;

    private bool playerInRange;

    public void Interact()
    {
        if (!playerInRange) return;

        StartCoroutine(Transition());
    }

    public void OnTouchingPlayer()
    {
        Debug.Log("Player in range of door");
        playerInRange = true;

        if (interactPrompt != null)
            interactPrompt.SetActive(true);
    }

    public void OnNotTouchingPlayer()
    {
        Debug.Log("Player out of range of door");
        playerInRange = false;

        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }

    private IEnumerator Transition()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);

        if (SceneFader.Instance != null)
            yield return SceneFader.Instance.FadeOut();

        SceneManager.LoadScene(sceneToLoad);

        yield return null;
    }
}