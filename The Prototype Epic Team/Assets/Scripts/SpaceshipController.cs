using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipController : MonoBehaviour
{
    public float horizontalInput;

    public float verticalInput;

    public float moveSpeed = 5.0f;

    public float turnSpeed;

    private SpawnManager spawnManager;
    public GameObject gameOverText;

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

        if (Input.GetKeyDown(KeyCode.R) && spawnManager.gameOver ==  true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spawnManager.gameOver = true;

            gameOverText.SetActive(true);

        }
    }
}
