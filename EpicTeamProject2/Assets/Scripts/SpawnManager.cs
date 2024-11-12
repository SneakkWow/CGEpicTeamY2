//Scott Abbinanti

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject[] enemies;

    public int roundNumber;

    public bool gameOver = false;

    public int spawnAmount = 5;

    public int enemyCount;

    public GameObject player;

    public int i;

    public bool inRound;


    // Start is called before the first frame update
    void Start()
    {
        roundNumber = 1;
        StartWave();

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (player == null)
        {
            gameOver = true;
        }
    }

    IEnumerator Spawn()
    {
        Debug.Log("In Spawn() lmao");

        //inRound = true;
        for (i = 0; i < 5 + roundNumber; i++)
        {
            SpawnSingleEnemy();
            yield return new WaitForSeconds(3f);
        }
        inRound = true;
    }

    IEnumerator WaveStarter()
    {
        while (gameOver == false)
        {
            //enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (inRound == false)
            {
                StartCoroutine(Spawn());
            }

            if (enemyCount == 0 && inRound == true)
            {
                roundNumber++;
                i = 0;
                inRound = false;
                Debug.Log("In that if statement bruh");

                yield return new WaitForSeconds(15);
            }
        }
        
    }

    public void StartWave()
    {
        StartCoroutine(WaveStarter());
    }

    public void StopWave()
    {
        StopCoroutine(WaveStarter());
    }

    void SpawnSingleEnemy()
    {
        int enemy = Random.Range(0, enemies.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 spawnLocation = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);

        Instantiate(enemies[enemy], spawnLocation, Quaternion.identity);
    }
}
