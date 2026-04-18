using UnityEngine;

public class SpawnPointSetter : MonoBehaviour
{
    public Vector3 playerPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        playerPosition = new Vector3 (collision.transform.position.x, collision.transform.position.y);
        ISetSpawnPoint spawnPoint = collision.GetComponent<ISetSpawnPoint>();
        if (spawnPoint!=null)
        {
            spawnPoint.setSpawnPoint(playerPosition);
        }
        
    }

}
