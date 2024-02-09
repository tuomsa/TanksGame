using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class WheelColliderGizmoDrawer : MonoBehaviour
{
    public Color gizmoColor = Color.green; // Voit vaihtaa Gizmon väriä Unity Editorissa

    void OnDrawGizmos()
    {
        WheelCollider wheelCollider = GetComponent<WheelCollider>();

        // Piirrä kehä, joka vastaa WheelColliderin säteen kokoa
        Gizmos.color = gizmoColor;
        Vector3 position = wheelCollider.transform.position;
        Vector3 wheelWorldPos;
        Quaternion wheelWorldRot;
        wheelCollider.GetWorldPose(out wheelWorldPos, out wheelWorldRot);

        // Piirrä kehä edustamaan WheelColliderin sijaintia ja kokoa
        Gizmos.DrawWireSphere(wheelWorldPos, wheelCollider.radius);
    }
}
