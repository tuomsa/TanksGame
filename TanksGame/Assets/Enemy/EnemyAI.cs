using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform player;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float attackRange = 1.5f;
    public float bulletSpeed = 10f;
    public float fireRate = 1f; // Rate of fire (bullets per second)
    private float nextFireTime = 0f; // Time when the enemy can fire next
    private int currentHealth = 100; // Maximum health of the enemy

    private int currentPatrolPointIndex = 0;
    private bool isChasing = false;

    void Update()
    {
        if (currentHealth <= 0)
        {
            // Enemy is defeated, perform defeat behavior
            Defeated();
            return;
        }

        if (!isChasing)
        {
            Patrol();
        }
        else
        {
            Chase();
        }
    }

    void Patrol()
    {
        Transform currentPatrolPoint = patrolPoints[currentPatrolPointIndex];
        float distance = Vector3.Distance(transform.position, currentPatrolPoint.position);

        if (distance < 0.1f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentPatrolPoint.position, patrolSpeed * Time.deltaTime);

        // Rotate towards next patrol point
        Vector3 patrolDirection = (currentPatrolPoint.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(patrolDirection.x, 0, patrolDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Stop and look at the player
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // Check if it's time to fire
            if (Time.time >= nextFireTime)
            {
                // Attack the player
                Attack();
                nextFireTime = Time.time + 1f / fireRate; // Update next fire time based on fire rate
            }
        }
    }

    void Attack()
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Calculate bullet direction towards player
        Vector3 direction = (player.position - transform.position).normalized;
        bulletRb.velocity = direction * bulletSpeed;

        // Destroy bullet after some time
        Destroy(bullet, 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
        }
        else if (other.CompareTag("PlayerBullet"))
        {
            // If the enemy is hit by a player bullet, reduce its health
            TakeDamage(10); // Assuming each bullet deals 10 damage
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
        }
    }

    void TakeDamage(int damageAmount)
    {
        // Reduce enemy's health
        currentHealth -= damageAmount;
        Debug.Log("Enemy health: " + currentHealth);

        // Check if the enemy's health has dropped to or below zero
        if (currentHealth <= 0)
        {
            // Enemy is defeated, perform defeat behavior
            Defeated();
        }
    }

    void Defeated()
    {
        Debug.Log("Enemy defeated!");
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}