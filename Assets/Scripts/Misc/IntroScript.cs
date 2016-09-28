using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

/* NOTES:
 * This is a prototype and test script for starting up the prototype SpiceRack project.
 * Once data can be loaded in from databases, it can be deleted.
 */

public class IntroScript : MonoBehaviour 
{
    public string FirstScene;
    public GameObject ModalBackground;
    public GameObject InstructionsPanel;
    public GameObject SuccessPanel;
    public Text SuccessPanelText;
    public Button SignInButton;

    void Start()
    {
        //PlayGamesPlatform.Activate();
        //SuccessPanel.SetActive(false);

        if (PlayerPrefs.HasKey(GameManager.instance.LevelKey))
        {
            string level = PlayerPrefs.GetString(GameManager.instance.LevelKey);
            PlayerPrefs.DeleteKey(GameManager.instance.LevelKey);

            GameManager.instance.scoreTracker.TotalScore = PlayerPrefs.GetFloat(GameManager.instance.ScoreKey);
            PlayerPrefs.DeleteKey(GameManager.instance.ScoreKey);

            GameManager.instance.scoreTracker.NumberOfSteps = PlayerPrefs.GetFloat(GameManager.instance.StepsKey);
            PlayerPrefs.DeleteKey(GameManager.instance.StepsKey);
            Application.LoadLevel(level);
        }
    }

    //public void SignIn()
    //{
    //    SuccessPanel.SetActive(true);
    //    SuccessPanelText.text = "Signing in...";
    //    SignInButton.interactable = false;

    //    Social.localUser.Authenticate((bool success) =>
    //    {
    //        SuccessPanel.SetActive(true);
    //        if (success)
    //        {
    //            SuccessPanelText.text = "Sign-In was successful";
    //        }
    //        else
    //        {
    //            SuccessPanelText.text = "Sign-In failed";
    //            SignInButton.interactable = true;
    //        }
    //    });
    //}

    //public void ShowAchievements()
    //{
    //    Social.ShowAchievementsUI();
    //}

    public void StartProject()
    {
        //Project testProject = SetUpTestProject();
        GameManager.instance.scoreTracker.ResetScore();
        Application.LoadLevel(FirstScene);
    }

    public void ShowInstructions(bool show)
    {
        ModalBackground.SetActive(show);
        InstructionsPanel.SetActive(show);
    }
}
