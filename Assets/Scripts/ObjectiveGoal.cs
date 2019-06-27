using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectiveGoal
{
    public bool completed;

    public int requiredAmount;
    public int currentAmount;
    public string[] requiredObject;

    public void CollectingInit(int amount, string[] name)
    {
        requiredAmount = amount;
        requiredObject = name;
    }

    public void CollectingComplete(string sellingObject)
    {
        foreach (string obj in requiredObject)
        {
            if (sellingObject == obj)
            {
                currentAmount++;
                break;
            }
            Debug.Log("sup");
        }

        if (requiredAmount >= currentAmount)
        {
            completed = true;
        }
    }

    public void RestrictionInit()
    {

    }

    public void TimeLimitInit()
    {

    }
}