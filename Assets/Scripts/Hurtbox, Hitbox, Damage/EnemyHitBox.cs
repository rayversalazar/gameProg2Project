using UnityEngine;

public class EnemyHitBox : MonoBehaviour, IDamageDealer
{
    [SerializeField] Enemy enemy;
    public int Damage => enemy.currentEnemyDamage;

}
