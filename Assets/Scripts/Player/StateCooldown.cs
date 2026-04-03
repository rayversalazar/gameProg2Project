using UnityEngine;

public class StateCooldown : MonoBehaviour
{
    [SerializeField]Player player;


    [SerializeField] float setDashCooldown;
    [SerializeField] float setPostHitImmunityCooldown;

    public float currentDashCooldown;
    public float currentPostHitImmunityCooldown;

    private void Awake()
    {
    }

    private void Start()
    {

        currentDashCooldown = setDashCooldown;
        currentPostHitImmunityCooldown = setPostHitImmunityCooldown;

    }
    void Update()
    {

        if (currentDashCooldown > 0)
        {
            currentDashCooldown -= Time.deltaTime;
        }
        if (currentPostHitImmunityCooldown > 0)
        {
            currentPostHitImmunityCooldown -= Time.deltaTime;
        }
        
    }

    public void startDashCooldown()
    {
        currentDashCooldown = setDashCooldown;
    }
    public void startPostHitImmunityCooldown()
    {
        currentPostHitImmunityCooldown = setPostHitImmunityCooldown;
    }
}
