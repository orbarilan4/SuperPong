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
        SceneManager.LoadScene("Soccer");
        PlayMenuSound();
    }

    public void ModesGame()
    {
        PlayMenuSound();
    }

    public void InstructionsGame()
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
