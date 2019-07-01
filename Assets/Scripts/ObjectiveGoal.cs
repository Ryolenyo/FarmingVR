using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectiveGoal
{
    public bool completed;

    public int requiredAmount;
    public int currentAmount;
	public int limit;
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
        }

        if (requiredAmount >= currentAmount)
        {
            completed = true;
        }
    }

    public void RestrictionInit()
    {
		
    }

    public void TimeLimitInit(int amount, string[] name, int time)
    {
		requiredAmount = amount;
        requiredObject = name;
		limit = time;
    }

	public void TimeLimitComplete(string sellingObject)
    {
        foreach (string obj in requiredObject)
        {
            if (sellingObject == obj)
            {
                currentAmount++;
                break;
            }
        }

        if (requiredAmount >= currentAmount)
        {
			GameObject timer = GameObject.Find("ScoreBoard").transform.Find("Timer").Find("Text").gameObject;
			Timer timerVariable = timer.GetComponent<Timer>();
			if (timerVariable.currentTime <= limit)
			{
	            completed = true;
			}
        }
    }
}