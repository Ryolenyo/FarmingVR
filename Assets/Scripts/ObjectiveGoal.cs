using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectiveGoal
{
    public ObjectiveType objectiveType;
}

public enum ObjectiveType
{
    Collecting,
    Restriction
}