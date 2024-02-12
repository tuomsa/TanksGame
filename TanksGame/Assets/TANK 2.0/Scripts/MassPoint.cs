using UnityEngine;

public class MassPoint : MonoBehaviour
{
    public Vector3 centerOfMassOffset;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateCenterOfMass();
    }

    void OnDrawGizmos()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        UpdateCenterOfMass(); // P‰ivit‰ painopiste Gizmojen piirt‰mist‰ varten

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.TransformPoint(rb.centerOfMass), 0.1f);
    }

    // Lis‰t‰‰n erillinen metodi painopisteen p‰ivitt‰miseen
    private void UpdateCenterOfMass()
    {
        if (rb != null)
        {
            rb.centerOfMass = centerOfMassOffset;
        }
    }
}
