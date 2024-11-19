//Scott Abbinanti

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void OpenLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
