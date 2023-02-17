using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene("PlayScene");

    }
    public void Options()
    {
        SceneManager.LoadScene("Options");



    }
    public void QuitGame()
    {

        Application.Quit();

    }
    public void BackToStart()
    {

        SceneManager.LoadScene("MainMenu");


    }
    public void Credits()
    {

        SceneManager.LoadScene("Credits");

    }
}
