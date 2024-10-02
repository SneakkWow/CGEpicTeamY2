using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rb;

    //private SpawnManager spawnManager;

    //private GameObject player;
    //public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();

        //player = GameObject.FindGameObjectWithTag("Player");

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);

        

        //this.SetTrajectory(spawnManager.rotation * (-1 * spawnManager.spawnDirection));
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if(transform.position.x > 35 || transform.position.x < -35 || transform.position.y > 35 || transform.position.y < -35)
        {
            Destroy(this.gameObject);
        }
    }

    private void SetTrajectory(Vector3 direction)
    {
        //Debug.Log("Trajectory set");

        rb.AddForce(direction);
    }
}
