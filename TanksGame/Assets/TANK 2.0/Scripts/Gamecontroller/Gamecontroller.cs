using UnityEngine;
using TMPro; // Jos k‰yt‰t TextMeshProa vihollisten m‰‰r‰n n‰ytt‰miseen

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int enemiesDestroyed = 0;
    public int totalEnemiesInLevel = 0;
    public ShutterControl gate; // Viittaus ShutterControl-skriptiin
    public TextMeshProUGUI enemiesInfoText; // UI-elementti, joka n‰ytt‰‰ tuhottujen vihollisten m‰‰r‰n

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            CountEnemiesInLevel();
            UpdateEnemiesInfoText(); // P‰ivit‰ UI-teksti heti pelin alkaessa
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void CountEnemiesInLevel()
    {
        totalEnemiesInLevel = FindObjectsOfType<EnemyAI>().Length;
        Debug.Log("Total enemies in level: " + totalEnemiesInLevel);
    }

    private void UpdateEnemiesInfoText()
    {
        if (enemiesInfoText != null)
            enemiesInfoText.text = "Enemies Destroyed: " + enemiesDestroyed + " / " + totalEnemiesInLevel;
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        UpdateEnemiesInfoText(); // P‰ivit‰ UI-teksti jokaisen tuhotun vihollisen j‰lkeen

        if (enemiesDestroyed >= totalEnemiesInLevel)
        {
            Debug.Log("All enemies defeated!");
            if (gate != null)
            {
                gate.OpenGate(); // Avaa portti
            }
        }
    }
}
