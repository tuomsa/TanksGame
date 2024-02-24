using UnityEngine;

public class BulletController : MonoBehaviour
{
    public AudioClip bulletSound; // Drag and drop your MP3 audio clip in the Inspector
    public AudioClip destructionSound; // Drag and drop another MP3 audio clip for destruction sound

    void Start()
    {
        // Play the audio clip if provided
        if (bulletSound != null)
        {
            // Play the bullet sound
            AudioSource.PlayClipAtPoint(bulletSound, transform.position);
        }
        else
        {
            Debug.LogWarning("No bullet sound assigned to the bullet.");
        }
    }

    void OnDestroy()
    {
        // Play the destruction sound if provided
        if (destructionSound != null)
        {
            // Play the destruction sound at the position of the bullet
            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
        }
        else
        {
            Debug.LogWarning("No destruction sound assigned.");
        }
    }
}
