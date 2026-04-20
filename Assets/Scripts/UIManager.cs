using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private DeathUI deathUI;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDeathUI()
    {
        Debug.Log("ShowDeathUI called");

        Debug.Log("UIManager Instance: " + Instance);
        Debug.Log("DeathUI reference: " + deathUI);

        if (deathUI == null)
        {
            Debug.LogError("❌ deathUI is NULL inside UIManager!");
            return;
        }

        deathUI.Show();
    }
}