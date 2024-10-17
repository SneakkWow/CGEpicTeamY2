using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
