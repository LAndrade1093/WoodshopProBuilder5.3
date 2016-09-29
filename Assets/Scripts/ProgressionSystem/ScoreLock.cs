using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// Tracks the requirements needed to unlock a project.
/// When all the requirements are met, the project is unlocked for the given player profile (usually the currently signed in player).
/// </summary>
public class ScoreLock : AbstractAsset
{
    private float _projectIDToUnlock;
    private List<ScoreRequirement> _minimumRequirements;
    
    public float ProjectIDToUnlock
    {
        get { return _projectIDToUnlock; }
        private set { _projectIDToUnlock = value; }
    }

    public List<ScoreRequirement> MinimumRequirements
    {
        get { return _minimumRequirements; }
        set { _minimumRequirements = value; }
    }

    public ScoreLock() 
        : base()
    {
        this.ProjectIDToUnlock = -1f;
        this.MinimumRequirements = new List<ScoreRequirement>();
    }

    public ScoreLock(float id)
        : base(id)
    {
        this.ProjectIDToUnlock = -1f;
        this.MinimumRequirements = new List<ScoreRequirement>();
    }

    public ScoreLock(float id, float associatedProjectID, ScoreRequirement singleRequirement)
        : base(id)
    {
        this.ProjectIDToUnlock = associatedProjectID;
        this.MinimumRequirements = new List<ScoreRequirement>();
        this.AddRequirement(singleRequirement);
    }

    public ScoreLock(float id, float associatedProjectID, List<ScoreRequirement> requirements)
        : base(id)
    {
        this.ProjectIDToUnlock = associatedProjectID;
        this.MinimumRequirements = new List<ScoreRequirement>();
        this.AddListOfRequirements(requirements);
    }

    public void AddListOfRequirements(List<ScoreRequirement> requirementsToAdd)
    {
        foreach (ScoreRequirement requirement in requirementsToAdd)
        {
            AddRequirement(requirement);
        }
    }

    public void AddRequirement(ScoreRequirement requirementToAdd)
    {
        MinimumRequirements.Add(requirementToAdd);

        requirementToAdd.SetAssociatedScoreLock(this);
    }

    public void RemoveListOfRequirements(List<ScoreRequirement> requirementsToRemove)
    {
        foreach (ScoreRequirement requirement in requirementsToRemove)
        {
            RemoveRequirement(requirement);
        }
    }

    public void RemoveRequirement(ScoreRequirement requirementToRemove)
    {
        requirementToRemove.SetAssociatedScoreLock(null);
        MinimumRequirements.Remove(requirementToRemove);
    }

    public bool AllRequirementsAreMetByPlayer(float playerProfileID)
    {
        bool requirementsMet = true;
        for (int i = 0; i < MinimumRequirements.Count && requirementsMet; i++)
        {
            requirementsMet = MinimumRequirements[i].ScoreRequirementMet(playerProfileID);
        }
        return requirementsMet;
    }

    public void UnlockProject(float playerProfileID, bool alertListeners = true)
    {
        bool projectAlreadyUnlocked = PlayerProjectLinkDatabase.Instance.IsProjectUnlockedForProfile(ProjectIDToUnlock, playerProfileID);
        if (!projectAlreadyUnlocked)
        {
            if (AllRequirementsAreMetByPlayer(playerProfileID))
            {
                PlayerProjectLinkDatabase.Instance.UnlockProjectForProfile(ProjectIDToUnlock, playerProfileID);
                if (alertListeners && onProjectUnlocked != null)
                {
                    Project project = ProjectsDatabase.Instance.RetrieveEntity(ProjectIDToUnlock);
                    onProjectUnlocked(this, new ScoreLockEventArgs(project));
                }
            }
        }
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        ScoreLock otherGate = (ScoreLock)obj;
        if (this.ID != otherGate.ID) return false;
        if (this.ProjectIDToUnlock != otherGate.ProjectIDToUnlock) return false;
        if (this.MinimumRequirements != otherGate.MinimumRequirements) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private event EventHandler onProjectUnlocked;
    public event EventHandler OnProjectUnlocked
    {
        add
        {
            if (value != null)
            {
                onProjectUnlocked += value;
            }
            else
            {
                Debug.LogError("NULL value cannot be assigned to OnProjectUnlocked");
            }
        }
        remove
        {
            onProjectUnlocked -= value;
        }
    }
}

public class ScoreLockEventArgs : EventArgs
{
    private float _projectID;
    private string _projectName;
    private float _projectSalePrice;

    public float ProjectID
    {
        get { return _projectID; }
        private set { _projectID = value; }
    }

    public string ProjectName
    {
        get { return _projectName; }
        private set { _projectName = value; }
    }

    public float ProjectSalePrice
    {
        get { return _projectSalePrice; }
        private set { _projectSalePrice = value; }
    }

    public ScoreLockEventArgs(Project project)
        : base()
    {
        this.ProjectID = project.ID;
        this.ProjectName = project.Name;
        this.ProjectSalePrice = project.SalePrice;
    }
}