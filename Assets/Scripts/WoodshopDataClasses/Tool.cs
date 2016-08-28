using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Tool : AbstractAsset, ICsvImportable
{
    [SerializeField]
    private string _displayName;
    [SerializeField]
    private Sprite _icon;

    public string DisplayName
    {
        get { return _displayName; }
        private set { _displayName = value; }
    }
    
    public Sprite Icon
    {
        get { return _icon; }
        private set { _icon = value; }
    }

    public Tool()
        : base()
    {
        this.DisplayName = string.Empty;
        this.Icon = null;
    }

    public Tool(float id) 
        : base(id)
    {
        this.DisplayName = string.Empty;
        this.Icon = null;
    }

    public Tool(float id, string name, Sprite icon)
        : base(id)
    {
        this.DisplayName = name;
        this.Icon = icon;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Tool otherTool = (Tool)obj;
        if (this.ID != otherTool.ID) return false;
        if (this.DisplayName != otherTool.DisplayName) return false;
        if (this.Icon != otherTool.Icon) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void CreateFromCSV(Dictionary<string, string> csvData)
    {
        float id;
        if(float.TryParse(csvData["tool_id"], out id))
        {
            ID = id;
        }
        else
        {
            Debug.Log("The value of tool_id was not a valid float value. Value Received: "+csvData["tool_id"]);
        }

        DisplayName = csvData["display_name"];

        Sprite icon = Resources.Load("ToolIcons/"+csvData["icon_filename"]) as Sprite;
        if(icon != null)
        {
            Icon = icon;
        }
        else
        {
            Debug.Log("Could not find the Sprite file with filename of " + csvData["tool_icon_filename"]);
        }
    }
}
