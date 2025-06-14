using UnityEngine;

public class NPCChasePlayer : MonoBehaviour
{

    public Transform player;
    public float chaseDistance = 10f;        // Distance within which NPC starts chasing
    public float stopDistance = 2f;          // Distance at which NPC stops near player
    public float hitObjectCheckDistance = 1f; // Distance to detect if player hits an object
    public float moveSpeed = 4f;             // NPC movement speed
    public float rotationSpeed = 5f;         // Speed at which NPC rotates toward player

    private bool isChasing = false;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogWarning("Player Transform is not assigned and no GameObject tagged 'Player' found.");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;

            if (IsPlayerHittingObject())
            {
                float closerStopDistance = stopDistance * 0.5f;
                if (distanceToPlayer > closerStopDistance)
                {
                    MoveTowardsPlayer();
                }
                else
                {
                    // Close enough, stop moving
                    isChasing = false;
                }
            }
            else
            {
                if (distanceToPlayer > stopDistance)
                {
                    MoveTowardsPlayer();
                }
                else
                {
                    // Close enough, stop moving
                    isChasing = false;
                }
            }
        }
        else
        {
            isChasing = false;
        }
    }

    private void MoveTowardsPlayer()
    {
        // Rotate smoothly towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Keep only horizontal rotation
        if (direction.magnitude == 0)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private bool IsPlayerHittingObject()
    {
        Vector3 rayOrigin = player.position + Vector3.up * 0.5f;
        Vector3 rayDirection = player.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, hitObjectCheckDistance))
        {
            // Detected object ahead of player
            return true;
        }
        return false;
    }
}

