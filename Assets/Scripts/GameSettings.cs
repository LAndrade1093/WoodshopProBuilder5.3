using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{
    private static string MusicKey = "musicVolume";
    private static string SFXKey = "sfxVolume";
    private static string TutorialsKey = "tutorialsSwitch";

    public static void SetMusicVolume(float amount)
    {
        float volume = RestrictVolume(amount);
        PlayerPrefs.SetFloat(MusicKey, volume);
    }

    public static float GetMusicVolume()
    {
        float volume = PlayerPrefs.GetFloat(MusicKey, 1);
        return volume;
    }

    public static void SetSFXVolume(float amount)
    {
        float volume = RestrictVolume(amount);
        PlayerPrefs.SetFloat(SFXKey, volume);
    }

    public static float GetSFXVolume()
    {
        float volume = PlayerPrefs.GetFloat(SFXKey, 1);
        return volume;
    }

    public static void SetTutorialsSwitch(bool enable)
    {
        int tutorialInt = (enable) ? 1 : 0;
        PlayerPrefs.SetInt(TutorialsKey, tutorialInt);
    }

    public static bool TutorialsAreOn()
    {
        int tutorialInt = PlayerPrefs.GetInt(TutorialsKey, 1);
        bool tutorialBool = (tutorialInt == 1) ? true : false;
        return tutorialBool;
    }

    private static float RestrictVolume(float amount)
    {
        float finalAmount = amount;
        if (amount < 0)
        {
            finalAmount = 0;
        }
        if (amount > 1)
        {
            finalAmount = 1;
        }
        return finalAmount;
    }
}