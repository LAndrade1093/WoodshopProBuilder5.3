using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class CSVImportTest : MonoBehaviour {

    public Text TextDisplay;

    public void ImportFromCSV()
    {
        TextAsset t = Resources.Load("GameCSVData/testingImport") as TextAsset;
        if(t == null)
        {
            Debug.Log("Not found");
        }
        else
        {
            Debug.Log("Found");
        }
        string text = t.text;
        string loadedData = "";
        string[] listOfText = text.Split('\n');
        foreach(string line in listOfText)
        {
            if (line.Length > 0)
            {
                string dataLine = "";
                string[] dataList = line.Split(',');
                foreach (string data in dataList)
                {
                    dataLine += data + " | ";
                }
                loadedData += dataLine + "\n";
                Debug.Log(dataLine);
            }
        }
        TextDisplay.text = loadedData;
    }
}

//string text = @"" + Application.dataPath + "/Resources/GameCSVData/testingImport.csv";
//StreamReader sr = new StreamReader(text);
//int lines = 1;
//string AllText = "";
//while (!sr.EndOfStream)
//{
//    string[] line = sr.ReadLine().Split(',');
//    string loadedText = "";
//    foreach (string data in line)
//    {
//        loadedText += data + " | ";
//    }
//    AllText += "Line " + lines + ": " + loadedText+"\n";
//    Debug.Log("Line "+lines+":" + loadedText);
//    lines++;
//}
//TextDisplay.text = AllText;







//text += "Data Path: "+Application.dataPath+"\n\n";
//text += "Persistant Data Path: " + Application.persistentDataPath+"\n\n";

//TextAsset csv = (TextAsset)Resources.Load("GameCSVData/testingImport", typeof(TextAsset));
//text += "Does \"testingImport.csv\" exists: ";
//text += (csv != null) ? "Yes" : "No";
//Debug.Log(text);
//TextDisplay.text = text;