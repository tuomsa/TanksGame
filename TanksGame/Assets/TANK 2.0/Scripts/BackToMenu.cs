using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuSceneName"); // Varmista, että "MainMenuSceneName" on päävalikkonäkymäsi nimi
    }
}
