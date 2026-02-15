using UnityEngine;

public class Spike : MonoBehaviour, IDamageDealer
{
    [SerializeField] int spikeDamage;
    [SerializeField] Player thisPlayer;
    public int Damage => spikeDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        thisPlayer.Respawn();
    }
}
