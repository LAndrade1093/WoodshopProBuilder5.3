using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ScoreLock
{
    private float nextID = 0f;
    private float _id;
    private float _projectIDToUnlock;
    private List<ScoreRequirement> _minimumRequirements;

    public float ID
    {
        get { return _id; }
        private set { _id = value; }
    }

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
    {
        this.ID = nextID++;
        this.ProjectIDToUnlock = -1f;
        this.MinimumRequirements = new List<ScoreRequirement>();
    }

    public ScoreLock(float associatedProjectID, ScoreRequirement singleRequirement)
    {
        this.ID = nextID++;
        this.ProjectIDToUnlock = associatedProjectID;
        this.MinimumRequirements = new List<ScoreRequirement>();
        this.AddRequirement(singleRequirement);
        UnlockProject(false);
    }

    public ScoreLock(float associatedProjectID, List<ScoreRequirement> requirements)
    {
        this.ID = nextID++;
        this.ProjectIDToUnlock = associatedProjectID;
        this.MinimumRequirements = new List<ScoreRequirement>();
        this.AddListOfRequirements(requirements);
        UnlockProject(false);
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

    public void UnlockProject(bool alertListeners = true)
    {
        bool projectAlreadyUnlocked = ScoreLockProfileLinkDatabase.IsProjectUnlockedForProfile(ProjectIDToUnlock, PlayerProfileDatabase.currentProfile.ID);
        if (!projectAlreadyUnlocked)
        {
            bool unlockingIsPossible = true;
            for (int i = 0; i < MinimumRequirements.Count && unlockingIsPossible; i++)
            {
                unlockingIsPossible = MinimumRequirements[i].ProjectScoreReachedRequiredScore();
            }
            if (unlockingIsPossible)
            {
                ScoreLockProfileLinkDatabase.UnlockProjectForProfile(ID, PlayerProfileDatabase.currentProfile.ID);
                if (alertListeners && onProjectUnlocked != null)
                {
                    Project project = ProjectsDatabase.RetrieveProject(ProjectIDToUnlock);
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