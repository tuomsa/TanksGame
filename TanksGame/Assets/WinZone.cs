using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public Canvas winCanvas;
    public AudioClip winSound; // Sound clip to play
    private bool isTriggered = false;

    private void Start()
    {
        winCanvas.gameObject.SetActive(false); // Initially hide the canvas
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            winCanvas.gameObject.SetActive(true); // Activate the canvas
            isTriggered = true; // Set the triggered flag to true
            PlayWinSound(); // Play the win sound
            Invoke("ReturnToMainMenu", 5f); // Invoke ReturnToMainMenu after 5 seconds
        }
    }

    private void PlayWinSound()
    {
        if (winSound != null)
        {
            AudioSource.PlayClipAtPoint(winSound, transform.position); // Play the sound clip at the position of the object
        }
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
