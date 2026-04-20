using UnityEngine;

public class SoleHurtbox : MonoBehaviour
{
    [SerializeField] Sole sole;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageDealer dmg = collision.GetComponent<IDamageDealer>();
        if (dmg != null)
        {
            sole.TakeDamage(dmg.Damage);
        }
    }
}
