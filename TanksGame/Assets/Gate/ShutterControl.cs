using UnityEngine;

public class ShutterControl : MonoBehaviour
{
    public float openHeight = 5.0f;
    public float closeHeight = 0.0f;
    public float moveSpeed = 5.0f;
    public Material redMaterial; // Punaisen valon materiaali
    public Material greenMaterial; // Vihre�n valon materiaali
    public Renderer bulbRenderer; // Mesh Renderer, johon materiaali asetetaan
    
    [SerializeField] private AudioClip openSound; // Avauksen ääni
    [SerializeField] private AudioClip closeSound; // Sulkemis ääni

    private bool isOpening = false;
    private bool isClosing = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Hakee shutterin audiosourcen
        audioSource.loop = false;
    }

    void Update()
    {
        // Avaa shutter
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            isOpening = true;
            isClosing = false;
            SetBulbColor(greenMaterial); // Vaihda valon materiaali vihre�ksi
            PlaySound(openSound);
        }

        // Sulje shutter
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            isClosing = true;
            isOpening = false;
            SetBulbColor(redMaterial); // Vaihda valon materiaali punaiseksi
            PlaySound(closeSound);
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

        // Tarkista onko saavutettu kohdekorkeus ja pys�yt� liike
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

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
