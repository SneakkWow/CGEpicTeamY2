using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMove : MonoBehaviour
{
    private GameObject player;
    public float speed = 1f;

    private Rigidbody rb;

    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();

        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //transform.rotation = Quaternion.LookRotation(playerPos);


    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //rb.AddRelativeForce(transform.forward * speed * Time.deltaTime);

        //transform.position += transform.forward * speed * Time.deltaTime;
    }
}
