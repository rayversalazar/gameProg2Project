using UnityEngine;

public class Spike : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int spikeDamage;

    public int Damage => spikeDamage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRespawn playerRespawn = collision.GetComponentInParent<IRespawn>();
        if (playerRespawn != null)
        {
            playerRespawn.Respawn();
        }
    }
}
