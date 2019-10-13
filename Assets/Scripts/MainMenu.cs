using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Intro");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        PlayMenuSound();
    }

    public void ModesGame()
    {
        PlayMenuSound();
    }

    public void ControlsGame()
    {
        PlayMenuSound();
    }

    // public void QuitGame()
    // {
    //     Debug.Log("Quit");
    //     FindObjectOfType<AudioManager>().Play("MenuButton");
    //     Application.Quit();
    // }

    public void PlayMenuSound()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }
}
