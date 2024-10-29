//Scott Abbinanti

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject[] enemies;

    public static int roundNumber = 1;

    public bool gameOver = false;
    public bool inRound = false;

    public int spawnAmount = 5;

    public bool enemiesLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        //StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {

        while(enemiesLeft == true && gameOver == false)
        {
            
            for(int i = 0; i < spawnAmount + roundNumber; i++)
            {
                SpawnSingleEnemy();
                yield return new WaitForSeconds(3f);
            }

        }
        
    }

    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }

    public void StopSpawning()
    {
        StopCoroutine(Spawn());
    }

    void SpawnSingleEnemy()
    {
        int enemy = Random.Range(0, enemies.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 spawnLocation = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);

        Instantiate(enemies[enemy], spawnLocation, Quaternion.identity);
    }
}
