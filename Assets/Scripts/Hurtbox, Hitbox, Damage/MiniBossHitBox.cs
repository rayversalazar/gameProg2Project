using UnityEngine;

public class MiniBossHitBox : MonoBehaviour, IDamageDealer
{
    [SerializeField] MiniBoss enemy;
    public int Damage => enemy.currentDamage;
}
