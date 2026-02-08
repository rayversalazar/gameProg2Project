using Unity.VisualScripting;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField] Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageDealer damageSource = other.GetComponent<IDamageDealer>();
        if (damageSource != null)
        {
            player.TakeDamage(damageSource.Damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
