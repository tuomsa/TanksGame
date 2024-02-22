using UnityEngine;

public class TankPatrolAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 5f;

    private int currentPatrolIndex = 0;

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogWarning("No patrol points assigned to the tank.");
            return;
        }

        // Move towards the current patrol point
        Vector3 targetPosition = patrolPoints[currentPatrolIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);

        // Rotate towards the target patrol point
        Vector3 patrolDirection = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(patrolDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);

        // Check if the tank has reached the patrol point
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Move to the next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    // Visualize patrol points in the scene view when the object is selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach (Transform point in patrolPoints)
        {
            Gizmos.DrawSphere(point.position, 0.3f);
        }
    }
}
