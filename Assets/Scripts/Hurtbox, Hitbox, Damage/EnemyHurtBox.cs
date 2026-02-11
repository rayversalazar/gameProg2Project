using UnityEngine;

public class EnemyHurtBox : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageDealer damageSource = other.GetComponent<IDamageDealer>();
        if (damageSource != null)
        {
            enemy.TakeDamage(damageSource.Damage, other.transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
