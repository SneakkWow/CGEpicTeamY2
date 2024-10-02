using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeStart : MonoBehaviour
{
    public GameObject panel;
    public GameObject button;

    public SpawnManager spawnManager;
    public Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        spawnManager.StartSpawning();
        timer.StartTimer();


        panel.SetActive(false);
        button.SetActive(false);
    }
}
