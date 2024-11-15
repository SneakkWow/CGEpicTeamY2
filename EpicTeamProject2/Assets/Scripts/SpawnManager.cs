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

    public int i = 0;

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
        //enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        /*if(enemyCount > 0)
        {
            inRound = true;
        }*/

        if (player == null)
        {
            gameOver = true;
        }
    }

    /*IEnumerator Spawn()
    {
        Debug.Log("In Spawn() lmao");

        inRound = true;
        for (i = 0; i < 5 + roundNumber; i++)
        {
            //inRound = true;
            SpawnSingleEnemy();
            yield return new WaitForSeconds(3f);
        }
        //inRound = true;
    }*/

    IEnumerator WaveStarter()
    {
        while (gameOver == false)
        {
            //enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            //StartCoroutine(Spawn());
            Debug.Log("In Spawn() lmao");

            //inRound = true;
            for (; i < 5 + roundNumber; i++)
            {
                //inRound = true;
                SpawnSingleEnemy();
                yield return new WaitForSeconds(3f);
                Debug.Log(i.ToString() + roundNumber.ToString());
            }
            Debug.Log("Exited FOR");

            /*if (i = 0)
            {
                //StartCoroutine(Spawn());
                Debug.Log("In Spawn() lmao");

                //inRound = true;
                for (; i < 5 + roundNumber; i++)
                {
                    //inRound = true;
                    SpawnSingleEnemy();
                    yield return new WaitForSeconds(3f);
                }
                //inRound = true;
            }*/
            /*if (GameObject.FindWithTag("Enemy") != null)
            {
                //yield return new WaitForSeconds(5f);
            }*/
                

            Debug.Log(GameObject.FindWithTag("Enemy").ToString());

            if (GameObject.FindWithTag("Enemy") == null)
            {
                
                roundNumber++;
                i = 0;
                Debug.Log(roundNumber.ToString());
                //inRound = false;
                Debug.Log("In that if statement bruh");

                yield return new WaitForSeconds(15f);
            }
            Debug.Log("Bottom of WHILE");
            Debug.Log(gameOver.ToString());
        }
        
    }

    public void StartWave()
    {
        StartCoroutine(WaveStarter());
        Debug.Log("Started");
    }

    public void StopWave()
    {
        StopCoroutine(WaveStarter());
        Debug.Log("Stopeed");
    }

    void SpawnSingleEnemy()
    {
        int enemy = Random.Range(0, enemies.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 spawnLocation = new Vector3(spawnPoints[spawnPoint].transform.position.x, spawnPoints[spawnPoint].transform.position.y, spawnPoints[spawnPoint].transform.position.z);

        Instantiate(enemies[enemy], spawnLocation, Quaternion.identity);
        Debug.Log("Emeny spawened");
    }
}
