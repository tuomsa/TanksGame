using UnityEngine;

public class SmokeController : MonoBehaviour
{
    public ParticleSystem smokeParticleSystem; // Liit‰ t‰m‰ Unity Editorissa
    private ParticleSystem.MainModule smokeMain;

    void Start()
    {
        smokeMain = smokeParticleSystem.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Eteenp‰in
        {
            smokeMain.gravityModifier = 0.1f; // Esimerkkiarvo, s‰‰d‰ tarpeen mukaan
            // Kun liikumme eteenp‰in, k‰‰nn‰mme emitterin taaksep‰in
            smokeParticleSystem.transform.localEulerAngles = new Vector3(0, 0, 0);
            if (!smokeParticleSystem.isPlaying)
                smokeParticleSystem.Play();
        }
        else if (Input.GetKey(KeyCode.S)) // Taaksep‰in
        {
            smokeMain.gravityModifier = 0.1f; // Esimerkkiarvo, s‰‰d‰ tarpeen mukaan
            // Kun liikumme taaksep‰in, k‰‰nn‰mme emitterin eteenp‰in
            smokeParticleSystem.transform.localEulerAngles = new Vector3(0, 180, 0);
            if (!smokeParticleSystem.isPlaying)
                smokeParticleSystem.Play();
        }
        else
        {
            if (smokeParticleSystem.isPlaying)
                smokeParticleSystem.Stop();
        }
    }
}
