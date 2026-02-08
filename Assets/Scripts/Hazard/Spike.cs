using UnityEngine;

public class Spike : MonoBehaviour, IDamageDealer
{
    [SerializeField] int spikeDamage;
    [SerializeField] float spikeKnockbackDuration;
    [SerializeField] int spikeKnockBackForce;
    public int Damage => spikeDamage;

    public float KnockbackDuration => spikeKnockbackDuration;

    public float KnockbackForce => spikeKnockBackForce;
}
