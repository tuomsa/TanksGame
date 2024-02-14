using UnityEngine;

public class ShotSound : MonoBehaviour
{
    public AudioClip shotSound; // Audio clip for the shot sound

    void Update()
    {
        // Check for left mouse button press
        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            // Play the shot sound
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }
}
