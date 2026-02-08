using UnityEngine;

public interface IDamageDealer
{
    int Damage { get; }
    float KnockbackDuration { get; }
    float KnockbackForce { get; }
}
