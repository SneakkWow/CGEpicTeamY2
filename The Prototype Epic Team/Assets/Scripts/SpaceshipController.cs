using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SpaceshipController : MonoBehaviour
{
    public float horizontalInput;

    public float verticalInput;

    public float moveSpeed = 5.0f;

    public float turnSpeed;

    private SpawnManager spawnManager;
    public GameObject gameOverText;
    public Timer timer;

    private bool won = false;

    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        if(verticalInput > 0)
        {
            transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);
        }


        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.R) && spawnManager.gameOver ==  true && won == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(transform.position.x >= 26)
        {
            transform.position = new Vector3(26, transform.position.y, transform.position.z);
        }
        if(transform.position.x <= -26)
        {
            transform.position = new Vector3(-26, transform.position.y, transform.position.z);
        }
        if(transform.position.y >= 14)
        {
            transform.position = new Vector3(transform.position.x, 14, transform.position.z);
        }
        if(transform.position.y <= -14)
        {
            transform.position = new Vector3(transform.position.x, -14, transform.position.z);
        }

        /*if (time.Minutes == 1 && time.Seconds == 12 && time.Milliseconds == 276)
        {
            spawnManager.gameOver = true;
            won = true;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spawnManager.gameOver = true;

            gameOverText.SetActive(true);

            timer.StopTimer();
        }
    }
}
