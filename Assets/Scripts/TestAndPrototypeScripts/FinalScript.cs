using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour 
{
    public Text PercentageText;
    public Text OriginalValueText;
    public Text FinalScoreText;

    void Start() 
    {
        float percent = GameManager.instance.scoreTracker.ScorePercentage;
        PercentageText.text = percent.ToString("F1") + "/100";

        OriginalValueText.text = "$" + GameManager.instance.scoreTracker.ProjectCashValue.ToString("F1");

        float finalValue = GameManager.instance.scoreTracker.CalculateCurrentCashValue();
        FinalScoreText.text = "$" + finalValue.ToString("F1");

        //Social.ReportProgress(WoodshopGPGIds.achievement_finish_your_first_project, 100.0f, (bool success) =>
        //{
        //    Debug.Log("Achivement was successful: " + success);
        //});
    }
}
