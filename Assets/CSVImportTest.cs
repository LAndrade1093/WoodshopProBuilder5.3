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
        if (t == null)
        {
            TextDisplay.text = "\"GameCSVData/testingImport\" was not found";
        }
        else
        {
            StreamReader sr = new StreamReader(new MemoryStream(t.bytes));
            string loadedData = "";
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                string loadedText = "";
                foreach (string data in line)
                {
                    loadedText += data + " | ";
                }
                loadedData += loadedText + "\n";
                Debug.Log(loadedText + "\n");
            }
            TextDisplay.text = loadedData;
        }
    }
}