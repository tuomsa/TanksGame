using UnityEngine;

public class ShutterControl : MonoBehaviour
{
    // Oletetaan, että shutter liikkuu ylös- ja alaspäin.
    // Aseta nämä arvot Unity-editorissa vastaamaan haluttua avaus- ja sulkukorkeutta.
    public float openHeight = 0.0f;
    public float closeHeight = 0.0f;
    public float moveSpeed = 5.0f;

    private bool isOpening = false;
    private bool isClosing = false;

    // Update kutsutaan kerran framea kohden
    void Update()
    {
        // Avaa shutter
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            isOpening = true;
            isClosing = false;
        }

        // Sulje shutter
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            isClosing = true;
            isOpening = false;
        }

        // Liikuta shutteria
        if (isOpening)
        {
            // Liiku kohti avauskorkeutta
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, openHeight, transform.position.z), step);

            // Tarkista, onko saavutettu avauskorkeus
            if (transform.position.y == openHeight)
            {
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            // Liiku kohti sulkukorkeutta
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, closeHeight, transform.position.z), step);

            // Tarkista, onko saavutettu sulkukorkeus
            if (transform.position.y == closeHeight)
            {
                isClosing = false;
            }
        }
    }
}
