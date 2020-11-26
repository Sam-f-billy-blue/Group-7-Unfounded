using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Code courtesy of https://www.youtube.com/watch?v=UjkSFoLxesw

    public NavMeshAgent agent;

    public Transform player;

    public WaypointController ways;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    public AudioSource beingChased;
    public AudioSource captured;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    public float deathRange;
    public bool playerInSightRange;
    public bool playerInDeathRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        ways = GetComponent<WaypointController>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInDeathRange = Physics.CheckSphere(transform.position, deathRange, whatIsPlayer);

        if (player != playerInSightRange && player != playerInDeathRange) Patrolling();

        if (player == playerInSightRange && player != playerInDeathRange) ChasePlayer();

        if (player == playerInSightRange && player == playerInDeathRange) KillPlayer();
    }

    private void Patrolling()
    {
        
         if (!walkPointSet) SearchWalkPoint(false);

         if (walkPointSet)
         {
             agent.SetDestination(walkPoint);
         }

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

         if (distanceToWalkPoint.magnitude < 1f)
         {
             walkPointSet = false;
             ways.targetWaypointIndex++;
         }
      

        if (ways.targetWaypointIndex == 13)
        {
            ways.targetWaypointIndex = 0;
        }
    }

    private void SearchWalkPoint(bool randomize)
    {
        if (randomize)
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
                walkPointSet = true;
        }
        else
        {

            walkPoint = ways.waypoints[ways.targetWaypointIndex].position;
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void KillPlayer()
    {
        transform.LookAt(player);
        
    }


}
