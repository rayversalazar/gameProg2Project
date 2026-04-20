using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [Range(0,1f)]float volume = 1f;
    public AudioClip attack;
    public AudioClip hit;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip walk;
    public AudioClip wallclimb;


    public void Play(AudioClip clip)
    {
        audioSource.pitch = Random.Range(0.90f, 1.05f);
        audioSource.PlayOneShot(clip, volume);
    }
}
