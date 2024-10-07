using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviorPlaytest : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    public float lookDuration = 3.0f;
    public float moveAwayDistance = 10.0f;
    public float checkRadius = 2.0f;
    public float moveAwaySpeed = 6.0f; // Speed when backing away
    public float normalSpeed = 3.5f;   // Normal speed when chasing
    public float resetChaseTime = 5.0f; // Time to reset back to chasing
    private float lookTimer = 0.0f;
    private bool isLooking = false;
    private bool isMovingAway = false;
    private float moveAwayTimer = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            Debug.LogError("Player not found in scene! Make sure the player has the 'Player' tag.");
        }

        // Set the agent to normal chasing speed
        agent.speed = normalSpeed;
        agent.acceleration = 8.0f;
        agent.angularSpeed = 120f;
        agent.stoppingDistance = 0.5f;
    }

    void Update()
    {
        if (isMovingAway)
        {
            moveAwayTimer += Time.deltaTime;
            // Reset to chasing after a certain time
            if (moveAwayTimer >= resetChaseTime)
            {
                ResetChasing();
            }
        }
        else
        {
            agent.SetDestination(target.transform.position); // Follow the player

            // Check if the player is looking at the monster
            isLooking = IsPlayerLookingAtMonster();

            if (isLooking)
            {
                lookTimer += Time.deltaTime;
                //Debug.Log("Player is looking at the monster. Timer: " + lookTimer);

                if (lookTimer >= lookDuration)
                {
                    StartBackingAway();
                }
            }
            else
            {
                lookTimer = 0.0f;
                //Debug.Log("Player stopped looking at the monster. Timer reset.");
            }
        }
    }

    bool IsPlayerLookingAtMonster()
    {
        Camera playerCamera = Camera.main;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                return true;
            }
        }

        return false;
    }

    void StartBackingAway()
    {
        Debug.Log("Player has been looking for 3 seconds. Monster backing away...");

        // Set the agent to move away speed
        agent.speed = moveAwaySpeed;
        isMovingAway = true;
        moveAwayTimer = 0.0f; // Reset the move-away timer

        // Calculate direction and move away
        Vector3 directionAwayFromPlayer = (transform.position - target.transform.position).normalized;
        Vector3 proposedPosition = transform.position + directionAwayFromPlayer * moveAwayDistance;

        NavMeshHit navHit;
        if (NavMesh.SamplePosition(proposedPosition, out navHit, checkRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(navHit.position);
        }
    }

    void ResetChasing()
    {
        Debug.Log("Monster reset to chasing mode.");

        // Reset the speed back to normal
        agent.speed = normalSpeed;
        isMovingAway = false; // Start chasing again
        moveAwayTimer = 0.0f; // Reset timer for future moves
    }
}
