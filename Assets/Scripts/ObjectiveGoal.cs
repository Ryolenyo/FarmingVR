using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectiveGoal
{
    public bool completed;

    public int requiredAmount;
    public int currentAmount;

    public void CollectingObjective(int amount, string[] name)
    {
        requiredAmount = amount;

        if (requiredAmount >= currentAmount)
        {
            completed = true;
        }
    }

    public void RestrictionObjective()
    {

    }

    public void TimeLimitObjective()
    {

    }
}