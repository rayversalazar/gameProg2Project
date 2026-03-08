using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [Range(0, 1f)] float volume = 1f;
    public AudioClip attack;
    public AudioClip hit;

    public void Play(AudioClip clip)
    {
        audioSource.pitch = Random.Range(0.90f, 1.05f);
        audioSource.PlayOneShot(clip, volume);
    }
}
