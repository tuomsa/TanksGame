using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] lights; // M‰‰rit‰ t‰m‰ Unityn Inspectorissa

    // Alustetaan valot pois p‰‰lt‰ kun peli alkaa
    private void Start()
    {
        // K‰yd‰‰n l‰pi kaikki valot ja kytket‰‰n ne pois p‰‰lt‰
        foreach (var light in lights)
        {
            light.enabled = false;
        }
    }

    private void Update()
    {
        // Tarkistetaan, onko "L" n‰pp‰int‰ painettu
        if (Input.GetKeyDown(KeyCode.L))
        {
            // K‰yd‰‰n kaikki valot l‰pi ja vaihdetaan niiden tila
            foreach (var light in lights)
            {
                light.enabled = !light.enabled; // Kytkee valon p‰‰lle, jos se on pois p‰‰lt‰ ja p‰invastoin
            }
        }
    }
}
