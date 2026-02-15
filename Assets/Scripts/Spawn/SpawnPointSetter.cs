using UnityEngine;

public class SpawnPointSetter : MonoBehaviour
{
    public Player thisPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        thisPlayer.currentSpawnPoint = transform.position;
    }

}
