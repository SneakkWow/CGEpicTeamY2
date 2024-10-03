using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehavior : MonoBehaviour
{
    public GameObject target;  // The player
    public NavMeshAgent agent; // The NavMeshAgent component
    public float lookDistance = 10f; // Distance for line of sight check
    public float freezeDuration = 2f; // Duration the monster will freeze
    private bool isFrozen = false; // Monster's frozen state

    public Flashlight currentFlashlight;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!isFrozen)
        {
            // Check if the player is looking at the monster
            if (IsPlayerLookingAtMonster() )
            {
                StartCoroutine(FreezeMonster());
            }
            else
            {
                agent.SetDestination(target.transform.position);
            }
        }
    }

    private bool IsPlayerLookingAtMonster()
    {
        Vector3 directionToMonster = transform.position - target.transform.position;
        float angle = Vector3.Angle(target.transform.forward, directionToMonster);

        // Check if the monster is within the player's field of view
        if (angle < 25f && directionToMonster.magnitude <= lookDistance)
        {
            RaycastHit hit;
            // Cast a ray from the player's position to the monster
            if (Physics.Raycast(target.transform.position, directionToMonster.normalized, out hit, lookDistance))
            {
                // Check if the ray hits the monster
                if (hit.collider.gameObject == gameObject)
                {
                    return true; // Player is looking at the monster
                }
            }
        }
        return false; // Player is not looking at the monster
    }

    private IEnumerator FreezeMonster()
    {
        isFrozen = true; // Freeze the monster
        agent.isStopped = true; // Stop the NavMeshAgent
        //agent.speed = 0f;
        yield return new WaitForSeconds(freezeDuration); // Wait for the freeze duration
        isFrozen = false; // Unfreeze the monster
        agent.isStopped = false; // Resume movement
    }
}
