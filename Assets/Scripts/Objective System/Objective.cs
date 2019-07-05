using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Objective
{
    public string description;
    public ObjectiveType type;
    public ObjectiveGoal goal;
	public int rewardScore;

   public void Init(int requiredAmount, string[] requiredObject, int time)
    {
        if(type == ObjectiveType.Collecting)
        {
            goal.CollectingInit(requiredAmount, requiredObject);
        }
        else if(type == ObjectiveType.Restriction)
        {
            goal.RestrictionInit(requiredObject);
        }
        else
        {
            goal.TimeLimitInit(requiredAmount, requiredObject, time);
        }
    }
}

public enum ObjectiveType
{
    Collecting,
    TimeLimit,
    Restriction
}