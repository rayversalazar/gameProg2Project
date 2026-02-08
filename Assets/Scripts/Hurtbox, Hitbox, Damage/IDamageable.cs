using UnityEngine;

public interface IDamageable
{
    void TakeDamage(IDamageDealer damageDealer, Transform otherPosition);

}
