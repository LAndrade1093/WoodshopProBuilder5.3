using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ToolsDatabase 
{
    private static Dictionary<float, Tool> toolsList;

    public static void ValidateDatabase()
    {
        if(toolsList == null)
        {
            toolsList = new Dictionary<float, Tool>();
        }
    }

    public static void CreateTool(Tool tool)
    {
        ValidateDatabase();
        if (!toolsList.ContainsKey(tool.ID))
        {
            toolsList.Add(tool.ID, tool);
        }
        else
        {
            Debug.LogError("Tools list already contains " + tool);
        }
    }

    public static void UpdateTool(Tool newTool)
    {
        ValidateDatabase();
        if (toolsList.ContainsKey(newTool.ID))
        {
            toolsList[newTool.ID] = newTool;
        }
        else
        {
            Debug.LogError("Tool with id \"" + newTool.ID + "\" was not found in the database");
        }
    }

    public static Tool RetrieveTool(float ID)
    {
        ValidateDatabase();
        Tool tool = null;
        if (toolsList.ContainsKey(ID))
        {
            tool = toolsList[ID];
        }
        else
        {
            Debug.LogError("Tool ID \"" + ID + "\" was not found in the database");
        }
        return tool;
    }

    public static bool DeleteTool(float ID)
    {
        ValidateDatabase();
        bool successful = false;
        if (toolsList.ContainsKey(ID))
        {
            successful = toolsList.Remove(ID);
        }
        else
        {
            Debug.LogError("Tool ID \"" + ID + "\" was not found in the database");
        }
        return successful;
    }

    public static bool DeleteTool(Tool toolToDelete)
    {
        ValidateDatabase();
        bool successful = false;
        if (toolsList.ContainsKey(toolToDelete.ID))
        {
            Tool toolRetrieved = RetrieveTool(toolToDelete.ID);
            if (toolRetrieved == toolToDelete)
            {
                successful = toolsList.Remove(toolToDelete.ID);
            }
            //else
            //{
            //    Debug.LogError("Tool to delete does not match the ID \"" + toolRetrieved.Id + "\" of the tool retrieved");
            //}
        }
        else
        {
            Debug.LogError(toolToDelete + " is not in the list");
        }
        return successful;
    }

    public static List<Tool> RetrieveAllTools()
    {
        ValidateDatabase();
        List<Tool> allTools = new List<Tool>();
        if (toolsList.Count > 0)
        {
            allTools = toolsList.Values.ToList();
        }
        return allTools;
    }
}


//public static void UpdateTool(string previousTool, string newTool)
//{
//    ValidateDatabase();
//    if (toolsList.Contains(previousTool))
//    {
//        int index = toolsList.IndexOf(previousTool);
//        toolsList[index] = newTool;
//    }
//    else
//    {
//        Debug.LogError(previousTool + " was not found within the Tools list");
//    }
//}