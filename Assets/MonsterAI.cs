using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Automatically find the player if not assigned
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= attackRange)
        {
            AttackPlayer();
        }
        else
        {
            // Move toward the player
            agent.SetDestination(player.position);
        }
    }

    void AttackPlayer()
    {
        // Stop moving to attack
        agent.isStopped = true;

        // For now, let's just log it. You'd trigger an animation here!
        Debug.Log("Monster is attacking!");

        // Face the player while attacking
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}