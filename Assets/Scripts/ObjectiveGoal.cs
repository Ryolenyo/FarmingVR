using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectiveGoal
{
    public ObjectiveType objectiveType;

    public int requiredAmount;
    public int currentAmount;

    
}

public enum ObjectiveType
{
    Collecting,
    TimeLimit,
    Restriction
}