using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroids;

    public bool gameOver = false;

    public float SpawnRate = 2.0f;

    public int spawnAmount;

    void StartSpawning()
    {
        InvokeRepeating("Spawn", SpawnRate, SpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        for(int i = 0; i < spawnAmount; i++)
        {

        }
    }
}
