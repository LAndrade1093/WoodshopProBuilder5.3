using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MaterialsDatabase
{
    private static Dictionary<float, WorkshopMaterial> materialsList;

    public static void ValidateDatabase()
    {
        if (materialsList == null)
        {
            materialsList = new Dictionary<float, WorkshopMaterial>();
        }
    }

    public static void CreateMaterial(WorkshopMaterial workshopMaterial)
    {
        ValidateDatabase();
        if (!materialsList.ContainsKey(workshopMaterial.ID))
        {
            materialsList.Add(workshopMaterial.ID, workshopMaterial);
        }
        else
        {
            Debug.LogError("Materials list already contains " + workshopMaterial);
        }
    }

    public static void UpdateMaterial(WorkshopMaterial newWorkshopMaterial)
    {
        ValidateDatabase();
        if (materialsList.ContainsKey(newWorkshopMaterial.ID))
        {
            materialsList[newWorkshopMaterial.ID] = newWorkshopMaterial;
        }
        else
        {
            Debug.LogError("Material with id \"" + newWorkshopMaterial.ID + "\" was not found in the database");
        }
    }

    public static WorkshopMaterial RetrieveMaterial(float ID)
    {
        ValidateDatabase();
        WorkshopMaterial wm = null;
        if (materialsList.ContainsKey(ID))
        {
            wm = materialsList[ID];
        }
        else
        {
            Debug.LogError("Material ID \"" + ID + "\" was not found in the database");
        }
        return wm;
    }

    public static bool DeleteMaterial(float ID)
    {
        ValidateDatabase();
        bool successful = false;
        if (materialsList.ContainsKey(ID))
        {
            successful = materialsList.Remove(ID);
        }
        else
        {
            Debug.LogError("Material ID \"" + ID + "\" was not found in the database");
        }
        return successful;
    }

    public static bool DeleteMaterial(WorkshopMaterial materialToDelete)
    {
        ValidateDatabase();
        bool successful = false;
        if (materialsList.ContainsKey(materialToDelete.ID))
        {
            WorkshopMaterial toolRetrieved = RetrieveMaterial(materialToDelete.ID);
            if (toolRetrieved == materialToDelete)
            {
                successful = materialsList.Remove(materialToDelete.ID);
            }
            //else
            //{
            //    Debug.LogError("Tool to delete does not match the ID");
            //}
        }
        else
        {
            Debug.LogError(materialToDelete + " is not in the list");
        }
        return successful;
    }

    public static List<WorkshopMaterial> RetrieveAllMaterials()
    {
        ValidateDatabase();
        List<WorkshopMaterial> allMaterials = new List<WorkshopMaterial>();
        if (materialsList.Count > 0)
        {
            allMaterials = materialsList.Values.ToList();
        }
        return allMaterials;
    }
}
