using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 2f;

    private Transform target;
    private NavMeshAgent navMeshAgent;
    private float nextAttackTime = 0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Cabin")?.transform;

        if (target == null)
        {
            Debug.LogError("Cabin not found! Make sure it has the 'Cabin' tag.");
        }
        else if (navMeshAgent == null)
        {
            Debug.LogError("Enemy does not have a NavMeshAgent component.");
        }
        else if (!navMeshAgent.isOnNavMesh)
        {
            Debug.LogError("Enemy is not on a NavMesh. Make sure it is properly set up.");
        }
        else
        {
            navMeshAgent.speed = moveSpeed;
            navMeshAgent.stoppingDistance = attackRange;
        }
    }

    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget > attackRange)
            {
                MoveToTarget();
            }
        }
    }

    void MoveToTarget()
    {
        if (navMeshAgent != null && navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cabin") && Time.time >= nextAttackTime)
        {
            // Perform attack logic here
            Debug.Log("Attacking CABIN!");

            // Apply damage to the CABIN or perform other attack actions
            // For example: target.GetComponent<CabinHealth>().TakeDamage(attackDamage);

            nextAttackTime = Time.time + attackCooldown;
        }
    }
}