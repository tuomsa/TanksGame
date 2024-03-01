using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneToUnload;

    void Start()
    {
        // Load the scene you want to unload asynchronously
        SceneManager.LoadSceneAsync(sceneToUnload, LoadSceneMode.Additive);
    }

    public void UnloadScene()
    {
        // Unload the scene
        SceneManager.UnloadSceneAsync(sceneToUnload);
         SceneManager.UnloadSceneAsync(sceneToUnload);
    }
}
