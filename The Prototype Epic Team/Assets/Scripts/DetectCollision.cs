using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{

    public bool gameOver = false;
    public bool youWin = false;
    public Text deathText;
    public Text winText;

    public MonsterBehaviorPlaytest monsterAnim;

    public MonoBehaviour script1;
    public MonoBehaviour script2;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && !youWin && Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
        else if (gameOver && youWin && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Scarcade", LoadSceneMode.Single); // Replace the current scene

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            GameOver();
            monsterAnim.anim.SetBool("playerDied", true);
            
        }

        else if (other.CompareTag("EscapePod"))
        {
            youWin = true; 
            GameOver();
            
        }
    }

    private void GameOver()
    {
        // Stop the game time

        //Disable the camera and flashlight controls
        script1.enabled = false;
        script2.enabled = false;


        //win text
        if (youWin)
        {
            gameOver = true;

            Debug.Log("You escaped!");

            winText.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
        else //lose text
        {
            gameOver = true;

            Debug.Log("Game Over!");

            deathText.gameObject.SetActive(true);
        }

        
    }

    private void RestartScene()
    {

        // Get the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}
