using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2ElectricBoogaloo : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject[] enemies;

    public int roundNumber;

    public bool gameOver = false;

    public int spawnAmount = 5;

    public int enemyCount;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        roundNumber = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    IEnumerator WaveSpawner()
    {
        for (int i = 0; i < 5 + roundNumber; i++)
        {
            SpawnSingleEnemy();
            yield return new WaitForSeconds(3f);
        }
    }

    void SpawnSingleEnemy()
    {
        int enemy = Random.Range(0, enemies.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 spawnLocation = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);

        Instantiate(enemies[enemy], spawnLocation, Quaternion.identity);
    }
}
