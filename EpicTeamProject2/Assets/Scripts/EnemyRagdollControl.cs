using UnityEngine;
using UnityEngine.AI;

public class EnemyRagdollControl : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;  // Reference to the NavMeshAgent
    private Rigidbody[] ragdollRigidbodies;  // All the rigidbodies in the ragdoll
    private Collider[] ragdollColliders;  // All the colliders in the ragdoll
    private Animator animator;  // Reference to the enemy's Animator for non-ragdoll control
    private FollowPlayer followPlayerScript;  // Reference to the FollowPlayer script

    private Collider mainCollider;  // Main collider attached to the top parent object

    private void Start()
    {
        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Get the Animator component (if any)
        animator = GetComponent<Animator>();

        // Get the FollowPlayer script component
        followPlayerScript = GetComponent<FollowPlayer>();

        // Get all rigidbodies and colliders in the ragdoll
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();

        // Get the main collider (usually attached to the parent object)
        mainCollider = GetComponent<Collider>();

        // Disable ragdoll at the start
        SetRagdollState(false);
    }

    // Method to enable/disable the ragdoll state
    public void SetRagdollState(bool state)
    {
        // Enable or disable ragdoll physics based on the state
        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = !state;  // Set kinematic mode depending on ragdoll state
            if (!state)
            {
                rb.velocity = Vector3.zero;  // Reset velocity when transitioning back to non-ragdoll mode
            }
        }

        // Enable or disable colliders based on the ragdoll state
        foreach (var col in ragdollColliders)
        {
            // Disable all ragdoll colliders except the main one
            if (col != mainCollider)
            {
                col.enabled = state;  // Enable colliders when ragdoll is active
            }
        }

        // Ensure the main collider is always enabled
        if (mainCollider != null)
        {
            mainCollider.enabled = true;  // Always keep the main collider enabled
        }

        // Disable the animator and NavMeshAgent when ragdoll is active
        if (animator != null)
        {
            animator.enabled = !state;  // Disable animator when ragdoll is active
        }

        if (followPlayerScript != null)
        {
            followPlayerScript.enabled = !state;  // Disable FollowPlayer script when ragdoll is active
        }

        // Disable NavMeshAgent if ragdoll is active, since the ragdoll will take over
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = !state;  // Disable navMeshAgent when ragdoll is active
        }
    }

    // Call this method to simulate the enemy being hit
    public void OnHit()
    {
        SetRagdollState(true);  // Enable ragdoll when hit
    }

    // Optionally, you can call this method to reset the ragdoll (e.g., when the enemy is revived or reset)
    public void ResetRagdoll()
    {
        SetRagdollState(false);  // Disable ragdoll and return to normal state
    }
}
