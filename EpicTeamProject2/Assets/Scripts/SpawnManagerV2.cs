//Scott Abbinanti

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManagerV2 : MonoBehaviour
{
    // variables for spawning enemies in general
    public GameObject[] enemies;
    public GameObject[] spawnPoints;

    public int spawnAmount = 5;

    public int enemyCount;

    public int waveNumber = 1;

    public bool gameOver = false;

    public bool inRound = false;

    private bool canRestart;

    public Text roundText;

    //variables based on whether enemies are attacking
    public bool startedAttacking = false;

    public Text winnerText;
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave(1));
        canRestart = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        roundText.text = "Round: " + waveNumber + "\nEnemies left: " + enemyCount;

        if(gameOver == false && enemyCount == 0 && inRound == false)
        {
            inRound = true;
            waveNumber++;
            StartCoroutine(SpawnWave(waveNumber));
        }

        if (canRestart == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Kaiser");
        }
    }

    IEnumerator SpawnWave(int waveNum)
    {
        // Countdown before starting the round
        if (waveNum > 1)
        {
            // 15 seconds countdown before the round starts
            for (int i = 15; i > 0; i--)
            {
                countdownText.text = "Next Round In: " + i.ToString();  // Update countdown text
                yield return new WaitForSeconds(1);  // Wait for 1 second
            }
        }

        if (waveNum > 10)
        {
            Time.timeScale = 0f;
            winnerText.text = "Congrats on getting past wave ten! Press R to go again";
            canRestart = true;
        }

        // Start spawning enemies after countdown
        for (int i = 0; i < waveNum + spawnAmount; i++)
        {
            countdownText.text = " ";
            SpawnSingleEnemy();
            yield return new WaitForSeconds(3);  // Delay between enemy spawns
        }

        inRound = false;
        countdownText.text = "";  // Optionally, clear the countdown text after the round starts
    }

    void SpawnSingleEnemy()
    {
        int enemy = Random.Range(0, enemies.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 spawnLocation = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);

        Instantiate(enemies[enemy], spawnLocation, Quaternion.identity);
    }
}
