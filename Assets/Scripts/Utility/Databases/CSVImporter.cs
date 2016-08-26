using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class CSVImporter
{
    public static List<string> LoadStringDataFromCSV(string fileName, string path = null)
    {
        List<string> loadedData = new List<string>();

        TextAsset t = Resources.Load("GameCSVData/testingImport") as TextAsset;
        if (t == null)
        {
            Debug.Log("\"GameCSVData/testingImport\" was not found");
        }
        else
        {
            StreamReader sr = new StreamReader(new MemoryStream(t.bytes));
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                string loadedText = "";
                foreach (string data in line)
                {
                    loadedText += data + " | ";
                }
                Debug.Log(loadedText + "\n");
            }
        }
        return new List<string>();
    }

    /// <summary>
    /// Saves data to the specified CSV file at the next available row
    /// </summary>
    /// <param name="data">The list of data to save as strings to the CSV</param>
    /// <param name="fileName">The name of the file (Do not include extension)</param>
    /// <param name="pathInResources">The path to the file within the Resources folder (Do not include /Resources/ in the path)</param>
    public static void SaveAssetToCSV(List<string> data, string fileName, string pathInResources = null)
    {

    }
}