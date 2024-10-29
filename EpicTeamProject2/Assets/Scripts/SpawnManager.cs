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

    public float spawnRate = 2.0f;
    public int spawnAmount = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int enemy = Random.Range(0, enemies.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
    }
}
