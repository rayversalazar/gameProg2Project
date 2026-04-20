using UnityEngine;

public class BossRoomController : MonoBehaviour
{
    [SerializeField] private RoomLock roomLock;
    [SerializeField] private MiniBossStateMachine[] bosses;

    private bool fightStarted = false;
    private int aliveBosses;

    private void Start()
    {
        aliveBosses = bosses.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger hit: ");

        if (fightStarted) return;

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered boss room");
            StartFight();
        }
    }

    private void StartFight()
    {
        fightStarted = true;

       
        if (roomLock == null)
        {
            Debug.LogError("RoomLock is NOT assigned!");
            return;
        }

        if (bosses == null || bosses.Length < 2)
        {
            Debug.LogError("Bosses array is missing or has less than 2 bosses!");
            return;
        }

        if (bosses[0] == null || bosses[1] == null)
        {
            Debug.LogError("One or both bosses are NOT assigned in Inspector!");
            return;
        }

        roomLock.LockRoom();

        foreach (var boss in bosses)
        {
            boss.ActivateBoss();
            boss.SetRoomController(this);
        }
    }

    public void OnBossDeath()
    {
        aliveBosses--;

        if (aliveBosses <= 0)
        {
            roomLock.UnlockRoom();
        }
    }

    public void ResetRoom()
    {
        fightStarted = false;
        aliveBosses = bosses.Length;
        roomLock.UnlockRoom();

        foreach (var boss in bosses)
        {
            if (boss != null)
            {
                boss.isAlive = true;
            }
        }
    }
}