using UnityEngine;

public class Spike : MonoBehaviour, IDamageDealer
{
    [SerializeField] int spikeDamage;
    public int Damage => spikeDamage;

}
