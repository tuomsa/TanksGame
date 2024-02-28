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


    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
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
        SoundFXManager.instance.PlaySoundFXClip(openSound, transform, 1f);
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
}
