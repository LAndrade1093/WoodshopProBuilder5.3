using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Testing the CSV importer
/// </summary>
public class CSVImportTest : MonoBehaviour {

    public Text TextDisplay;

    public void ImportFromCSV()
    {
        string filePath = "GameCSVData/";
        string fileName = "testingImport";
        List<Dictionary<string, string>> data = CSVImporter.LoadStringDataFromCSV(fileName, filePath);
        string loadedData = "";
        string keys = "";
        foreach(string key in data[0].Keys)
        {
            keys += key + " | ";
        }
        loadedData += keys + "\n";
        Debug.Log(keys);

        foreach (Dictionary<string, string> dictionaryRow in data)
        {
            string loadedText = dictionaryRow["id"] + " | " + dictionaryRow["enum"] + " | " + dictionaryRow["name"];
            loadedData += loadedText + "\n";
            Debug.Log(loadedText + "\n");
        }
        TextDisplay.text = loadedData;
    }
}