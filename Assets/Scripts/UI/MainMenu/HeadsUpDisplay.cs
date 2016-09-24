using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeadsUpDisplay : MonoBehaviour
{
    public Text CurrentProjectText;
    public Text CompletedProjectsText;
    public Text RankText;
    public Text CashAmountText;

    void Awake()
    {
        PlayerProfile p = PlayerProfileDatabase.Instance.currentProfile;
        if(p == null)
        {
            //Test Data
            AddCurrentProjectName("Spice Rack");
            AddNumberOfCompleted(1);
            AddCurrentPlayerRank(WoodshopRank.Hobbyist);
            AddCurrentPlayerCashAmount(12.3464f);
        }
        else
        {
            /*
             * When data can be loaded in, add name of current project the player is working on
             */
            /*
            * When data can be loaded in, get the number of projects the player has completed
            */
            AddCurrentPlayerRank(p.Rank);
            Inventory playerInventory = InventoryDatabase.Instance.GetInventoryByPlayer(p.ID);
            AddCurrentPlayerCashAmount(playerInventory.Cash);
        }
    }

    public void AddCurrentProjectName(string project)
    {
        if(string.IsNullOrEmpty(project))
        {
            CurrentProjectText.text = "None";
        }
        else
        {
            CurrentProjectText.text = project;
        }
    }

    public void AddNumberOfCompleted(int numberOfCompletedProjects = 0)
    {
        CompletedProjectsText.text = numberOfCompletedProjects.ToString();
    }

    public void AddCurrentPlayerRank(WoodshopRank rank)
    {
        RankText.text = rank.ToString();
    }

    public void AddCurrentPlayerCashAmount(float cashAmount)
    {
        CashAmountText.text = "$"+cashAmount.ToString("0.00"); ;
    }
}
