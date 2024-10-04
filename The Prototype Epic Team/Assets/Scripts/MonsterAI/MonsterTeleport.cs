using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterTeleport : MonoBehaviour
{
    public GameObject target;  // The player
    //public NavMeshAgent agent; // The NavMeshAgent component
    //public float lookDistance = 10f; // Distance for line of sight check
    public float freezeDuration = 20f; // Duration the monster will freeze
    public float jumpscareDuration = 1f;
    private bool isFrozen = false; // Monster's frozen state

    //public Flashlight currentFlashlight;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!isFrozen)
        {
            gameObject.SetActive(true);
            Jumpscare();
            
        }
    }

    private void Jumpscare()
    {
        transform.position = target.transform.position;
        StartCoroutine(CurrentJumpscare());
        
    }

    private IEnumerator CurrentJumpscare()
    {
        isFrozen = true; // Freeze the monster
        yield return new WaitForSeconds(jumpscareDuration); // Wait for the freeze duration
        StartCoroutine(WaitForJumpscare());
    }

    private IEnumerator WaitForJumpscare()
    {
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(freezeDuration); // Wait for the freeze duration
        isFrozen = false; // Unfreeze the monster
    }
}
