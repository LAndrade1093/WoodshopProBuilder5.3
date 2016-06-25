using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeadsUpDisplay : MonoBehaviour
{
    public Text CurrentProjectText;
    public Text CompletedProjectsText;
    public Text RankText;
    public Text CashAmountText;

    public void AddCurrentProjectName(Project project)
    {
        if(project == null)
        {
            CurrentProjectText.text = "None";
        }
        else
        {
            CurrentProjectText.text = project.Name;
        }
    }
}
