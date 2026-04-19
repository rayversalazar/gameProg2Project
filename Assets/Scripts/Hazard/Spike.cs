using UnityEngine;

public class Spike : MonoBehaviour { 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRespawn playerRespawn = collision.GetComponentInParent<IRespawn>();
        if (playerRespawn != null)
        {
            playerRespawn.Respawn();
        }
    }
}
