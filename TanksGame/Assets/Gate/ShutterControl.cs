using UnityEngine;

public class ShutterControl : MonoBehaviour
{
    public float openHeight = 5.0f;
    public float closeHeight = 0.0f;
    public float moveSpeed = 5.0f;
    public Material redMaterial;
    public Material greenMaterial;
    public Renderer bulbRenderer;

    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    private bool isOpening = false;
    private bool isClosing = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    void Update()
    {
        MoveShutter();
    }

    public void OpenGate()
    {
        isOpening = true;
        isClosing = false;
        SetBulbColor(greenMaterial);
        PlaySound(openSound);
    }

    private void MoveShutter()
    {
        if (isOpening)
        {
            MoveTowardsHeight(openHeight);
        }
        else if (isClosing)
        {
            MoveTowardsHeight(closeHeight);
        }
    }

    private void MoveTowardsHeight(float targetHeight)
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), step);

        if (transform.position.y == targetHeight)
        {
            isOpening = isClosing = false;
        }
    }

    private void SetBulbColor(Material newMaterial)
    {
        if (bulbRenderer != null)
        {
            bulbRenderer.material = newMaterial;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
