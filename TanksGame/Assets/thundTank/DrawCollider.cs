using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class WheelColliderGizmoDrawer : MonoBehaviour
{
    public Color gizmoColor = Color.green; // Voit vaihtaa Gizmon v�ri� Unity Editorissa

    void OnDrawGizmos()
    {
        WheelCollider wheelCollider = GetComponent<WheelCollider>();

        // Piirr� keh�, joka vastaa WheelColliderin s�teen kokoa
        Gizmos.color = gizmoColor;
        Vector3 position = wheelCollider.transform.position;
        Vector3 wheelWorldPos;
        Quaternion wheelWorldRot;
        wheelCollider.GetWorldPose(out wheelWorldPos, out wheelWorldRot);

        // Piirr� keh� edustamaan WheelColliderin sijaintia ja kokoa
        Gizmos.DrawWireSphere(wheelWorldPos, wheelCollider.radius);
    }
}
