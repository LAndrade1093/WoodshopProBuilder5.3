using UnityEngine;
using System.Collections;

public class SettingsUI : MonoBehaviour 
{
    public GameObject TutorialsOnButton;
    public GameObject TutorialsOffButton;

    public void Start()
    {
        if (GameSettings.TutorialsAreOn())
        {
            TutorialsOnButton.SetActive(false);
            TutorialsOffButton.SetActive(true);
        }
        else
        {
            TutorialsOnButton.SetActive(true);
            TutorialsOffButton.SetActive(false);
        }
    }

    public void ChangeMusicVolume(float changedVolume)
    {
        GameSettings.SetMusicVolume(changedVolume);
    }

    public void ChangeSFXVolume(float changedVolume)
    {
        GameSettings.SetSFXVolume(changedVolume);
    }

    public void EnableTutorials()
    {
        if (TutorialsOnButton != null && TutorialsOffButton != null)
        {
            GameSettings.SetTutorialsSwitch(true);
            TutorialsOnButton.SetActive(true);
            TutorialsOffButton.SetActive(false);
        }
    }

    public void DisableTutorials()
    {
        if (TutorialsOnButton != null && TutorialsOffButton != null)
        {
            GameSettings.SetTutorialsSwitch(false);
            TutorialsOnButton.SetActive(false);
            TutorialsOffButton.SetActive(true);
        }
    }
}