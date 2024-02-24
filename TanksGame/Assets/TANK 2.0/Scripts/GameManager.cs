using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public float restartDelay = 2f; // Delay before restarting the game

    void Update()
    {
        // Check if the player object is destroyed
        if (player == null)
        {
            // Start the coroutine to restart the game after a delay
            StartCoroutine(RestartGameWithDelay());
        }
    }

    IEnumerator RestartGameWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(restartDelay);

        // Restart the game by reloading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
