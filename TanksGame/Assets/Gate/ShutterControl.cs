using UnityEngine;

public class ShutterControl : MonoBehaviour
{
    public float openHeight = 5.0f;
    public float closeHeight = 0.0f;
    public float moveSpeed = 5.0f;
    public Material redMaterial; // Punaisen valon materiaali
    public Material greenMaterial; // Vihreän valon materiaali
    public Renderer bulbRenderer; // Mesh Renderer, johon materiaali asetetaan

    private bool isOpening = false;
    private bool isClosing = false;

    void Update()
    {
        // Avaa shutter
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            isOpening = true;
            isClosing = false;
            SetBulbColor(greenMaterial); // Vaihda valon materiaali vihreäksi
        }

        // Sulje shutter
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            isClosing = true;
            isOpening = false;
            SetBulbColor(redMaterial); // Vaihda valon materiaali punaiseksi
        }

        // Liikuta shutteria
        MoveShutter();
    }

    void MoveShutter()
    {
        if (isOpening)
        {
            // Liiku kohti avauskorkeutta
            MoveTowardsHeight(openHeight);
        }
        else if (isClosing)
        {
            // Liiku kohti sulkukorkeutta
            MoveTowardsHeight(closeHeight);
        }
    }

    void MoveTowardsHeight(float targetHeight)
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), step);

        // Tarkista onko saavutettu kohdekorkeus ja pysäytä liike
        if (transform.position.y == targetHeight)
        {
            isOpening = isClosing = false;
        }
    }

    void SetBulbColor(Material newMaterial)
    {
        if (bulbRenderer != null)
        {
            bulbRenderer.material = newMaterial;
        }
        else
        {
            Debug.LogWarning("Bulb renderer not assigned.");
        }
    }
}
