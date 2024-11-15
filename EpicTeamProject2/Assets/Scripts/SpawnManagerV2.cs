//Scott Abbinanti

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerV2 : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawnPoints;

    public int spawnAmount = 5;

    public int enemyCount;

    public int waveNumber = 1;

    public bool gameOver = false;

    public bool inRound = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave(1));
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(enemyCount == 0 && inRound == false)
        {
            inRound = true;
            waveNumber++;
            StartCoroutine(SpawnWave(waveNumber));
        }
    }

    IEnumerator SpawnWave(int waveNum)
    {
        if (waveNum > 1)
        {
            yield return new WaitForSeconds(15);
        }
        for (int i = 0; i < waveNum + spawnAmount; i++)
        {
            SpawnSingleEnemy();
            yield return new WaitForSeconds(3);
        }
        inRound = false;
    }

    void SpawnSingleEnemy()
    {
        int enemy = Random.Range(0, enemies.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 spawnLocation = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);

        Instantiate(enemies[enemy], spawnLocation, Quaternion.identity);
    }
}
