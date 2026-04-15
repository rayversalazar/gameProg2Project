using UnityEngine;

public class Spike : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int spikeDamage;
    [SerializeField] private Player thisPlayer;

    public int Damage => spikeDamage;

    private void Awake()
    {
        if (thisPlayer == null)
        {
            thisPlayer = FindObjectOfType<Player>();
            if (thisPlayer == null)
                Debug.LogWarning($"Spike.Awake: Player not found in scene for '{gameObject.name}'.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collidingPlayer = collision.GetComponent<Player>() ?? collision.GetComponentInParent<Player>();
        if (collidingPlayer != null)
        {
            collidingPlayer.Respawn();
            return;
        }

        if (thisPlayer != null)
            thisPlayer.Respawn();
    }
}
