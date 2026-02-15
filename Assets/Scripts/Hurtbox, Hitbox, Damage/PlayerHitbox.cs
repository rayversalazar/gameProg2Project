using UnityEngine;

public class PlayerHitbox : MonoBehaviour, IDamageDealer
{
    [SerializeField]Player player;
    public int Damage => player.currentDamage;

}
