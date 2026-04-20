using UnityEngine;

public class RoomLock : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;

    public void LockRoom()
    {
        foreach (GameObject door in doors)
            door.SetActive(true);
    }

    public void UnlockRoom()
    {
        foreach (GameObject door in doors)
            door.SetActive(false);
    }
}