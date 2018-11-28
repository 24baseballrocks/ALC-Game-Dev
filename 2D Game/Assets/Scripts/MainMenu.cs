using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Use this for initialization
    public int levelToLoad;


    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);

    }
    public void LevelExit()
    {
        Application.Quit();
    }
}
