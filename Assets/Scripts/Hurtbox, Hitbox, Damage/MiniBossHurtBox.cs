using UnityEngine;

public class MiniBossHurtBox : MonoBehaviour
{
    [SerializeField] MiniBoss enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageDealer damageSource = other.GetComponent<IDamageDealer>();
        if (damageSource != null)
        {
            enemy.TakeDamage(damageSource.Damage);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        IDamageDealer damageSource = other.GetComponent<IDamageDealer>();
        if (damageSource != null)
        {
            enemy.spriteRenderer.color = Color.red;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        IDamageDealer damageSource = other.GetComponent<IDamageDealer>();
        if (damageSource != null)
        {
            enemy.spriteRenderer.color = Color.white;
        }
    }
}
