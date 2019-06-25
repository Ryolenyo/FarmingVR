using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Objective
{
    public string title;
    public bool isDone;
    public ObjectiveType type;
}

public enum ObjectiveType
{
    Collecting,
    ItemRestriction,
    TimeLimit
}