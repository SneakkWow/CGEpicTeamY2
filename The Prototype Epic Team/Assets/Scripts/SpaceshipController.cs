//Scott Abbinanti 

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

    public bool canMove = true;

    private SpawnManager spawnManager;
    public GameObject gameOverText;
    public Timer timer;

    public ParticleSystem explosion;
    public AudioClip crash;
    public AudioSource playerAudio;

    public GameObject videoPlayer;
    public GameObject rawImage;

    public bool won = false;

    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        playerAudio = GetComponent<AudioSource>();
        //Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");


        if (canMove)
        {
            if (verticalInput > 0)
            {
                transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);
            }


            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

            

            if (transform.position.x >= 26)
            {
                transform.position = new Vector3(26, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -26)
            {
                transform.position = new Vector3(-26, transform.position.y, transform.position.z);
            }
            if (transform.position.y >= 14)
            {
                transform.position = new Vector3(transform.position.x, 14, transform.position.z);
            }
            if (transform.position.y <= -14)
            {
                transform.position = new Vector3(transform.position.x, -14, transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && spawnManager.gameOver == true && won == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (won)
        {
            spawnManager.gameOver = true;
            playerAudio.Pause();
            rawImage.SetActive(true);
            videoPlayer.SetActive(true);


            StartCoroutine(LoadingNextScene());
        }

    }


    IEnumerator LoadingNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Kaisers Tilemap");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            spawnManager.gameOver = true;

            gameOverText.SetActive(true);

            timer.StopTimer();

            explosion.Play();

            if (!won)
            {
                playerAudio.PlayOneShot(crash, 2.0f);
            }
            //freeze player movement
            canMove = false;
        }
    }
}
