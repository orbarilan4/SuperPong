using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int modePick = 0; // 0 - soccer, 1 - tennis

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    public void PlayGame()
    {
        Debug.Log("modePick: " + modePick);
        if (modePick == 0)
        {
            SceneManager.LoadScene("Soccer");
        }
        else if (modePick == 1)
        {
            SceneManager.LoadScene("Tennis");
        }
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

    public void PlayMenuSound()
    {
        FindObjectOfType<AudioManager>().Play("MenuButton");
    }

    public void pickSoccer()
    {
        modePick = 0;
        PlayMenuSound();
    }

    public void pickTennis()
    {
        modePick = 1;
        PlayMenuSound();
    }
}
