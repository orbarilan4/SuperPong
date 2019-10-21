using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public static int modePick = 0; // 0 - soccer, 1 - tennis
    public TextMeshProUGUI soccerModeText, tennisModeText;
    public TMP_ColorGradient red, green;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    public void PlayGame()
    {
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
        setModesColors();
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
        setModesColors();
    }

    public void pickTennis()
    {
        modePick = 1;
        PlayMenuSound();
        setModesColors();
    }

    public void setModesColors()
    {
        if (modePick == 0)
        {
            soccerModeText.colorGradientPreset = green;
            tennisModeText.colorGradientPreset = red;

        }
        else if (modePick == 1)
        {
            tennisModeText.colorGradientPreset = green;
            soccerModeText.colorGradientPreset = red;
        }
    }
}
