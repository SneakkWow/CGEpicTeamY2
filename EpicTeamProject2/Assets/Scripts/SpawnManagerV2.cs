//Scott Abbinanti

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //variables based on whether enemies are attacking
    public bool startedAttacking = false;

    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave(1));
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(gameOver == false && enemyCount == 0 && inRound == false)
        {
            inRound = true;
            waveNumber++;
            StartCoroutine(SpawnWave(waveNumber));
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
