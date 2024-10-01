using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroids;

    public bool gameOver = false;

    public float SpawnRate = 2.0f;

    public int spawnAmount = 1;

    public float spawnDistance = 25.0f;

    public float trajectoryVariance = 15.0f;

    void Start()
    {
        StartSpawning();
    }

    void StartSpawning()
    {
        //InvokeRepeating("Spawn", SpawnRate, SpawnRate);
        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            int prefabIndex = Random.Range(0, asteroids.Length);

            Instantiate(asteroids[prefabIndex], spawnPoint, rotation);
        }
    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while (gameOver == false)
        {
            Spawn();

            yield return new WaitForSeconds(1f);
        }
    }
}
