using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class CSVImporter
{
    private const char CommaDataSeparator = ',';

    public static List<Dictionary<string, string>> LoadStringDataFromCSV(string csvFileName, string pathFromResources = null)
    {
        string fullPath = (string.IsNullOrEmpty(pathFromResources)) ? csvFileName : pathFromResources + csvFileName;
        List<string> headers = new List<string>();
        List<Dictionary<string, string>> loadedData = new List<Dictionary<string, string>>();
        TextAsset t = Resources.Load(fullPath) as TextAsset;
        if (t == null)
        {
            throw new FileNotFoundException("CSV file \"Assets/Resources/" + fullPath + "\" could not be found.");
        }
        else
        {
            StreamReader sr = new StreamReader(new MemoryStream(t.bytes));
            bool headersStored = false;
            int rowNumber = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if(headersStored)
                {
                    string[] columnData = line.Split(CommaDataSeparator);
                    if(columnData.Length == headers.Count)
                    {
                        Dictionary<string, string> row = new Dictionary<string, string>();
                        for (int i = 0; i < columnData.Length; i++)
                        {
                            row.Add(headers[i], columnData[i]);
                        }
                        loadedData.Add(row);
                    }
                    else
                    {
                        throw new System.Exception("The number of columns in row "+ rowNumber + " does not match the number of headers in the CSV file \"Assets/Resources/" + fullPath + ".csv\"");
                    }
                }
                else
                {
                    headersStored = true;
                    string[] headerData = line.Split(CommaDataSeparator);
                    foreach (string header in headerData)
                    {
                        headers.Add(header);
                    }
                }
                rowNumber++;
            }
        }
        return loadedData;
    }
}