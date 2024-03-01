using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoopingMusic : MonoBehaviour
{
    public AudioClip musicClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // Set looping to true
        audioSource.clip = musicClip;
        audioSource.Play(); // Start playing the music clip
    }
}
