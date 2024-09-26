using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehavior : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;

    //public Transform goal;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        //agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
    void Wander()
    {
       
    }

    

}
