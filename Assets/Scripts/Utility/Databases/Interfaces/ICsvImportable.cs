using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ICsvImportable
{
    void CreateFromCSV(Dictionary<string, string> csvData);
}
