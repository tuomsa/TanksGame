using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuSceneName"); // Varmista, ett‰ "MainMenuSceneName" on p‰‰valikkon‰kym‰si nimi
    }
}
