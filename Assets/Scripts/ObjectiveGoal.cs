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
	private bool objectiveFailed = false;

	// COLLECTING TYPE

    public void CollectingInit(int amount, string[] name)
    {
        requiredAmount = amount;
        requiredObject = name;

		//GameObject basket = GameObject.Find("Basket").transform.Find("basketVoid").gameObject;
		GameObject basket = GameObject.Find("Basket/basketVoid");
		BasketBehavior basketVariable = basket.GetComponent<BasketBehavior>();
		basketVariable.objectiveChecker = true;
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

	// RESTRCTION TYPE
 
    public void RestrictionInit(string[] name)
    {
		requiredObject = name;

		//GameObject checker = GameObject.Find("Objective System").transform.Find("RestrictionChecker").gameObject;
		GameObject checker = GameObject.Find("Objective System/RestrictionChecker");
		RestrictionCheck checkerVariable = checker.GetComponent<RestrictionCheck>();
		checkerVariable.checker = true;
		checkerVariable.name = requiredObject;
    }

	public void RestrictionFailed()
    {
        objectiveFailed = true;
    }

	// TIME LIMIT TYPE

    public void TimeLimitInit(int amount, string[] name, int time)
    {
		requiredAmount = amount;
        requiredObject = name;
		limit = time;

		//GameObject basket = GameObject.Find("Basket").transform.Find("basketVoid").gameObject;
		GameObject basket = GameObject.Find("Basket/basketVoid");
		BasketBehavior basketVariable = basket.GetComponent<BasketBehavior>();
		basketVariable.objectiveChecker = true;
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
			//GameObject timer = GameObject.Find("ScoreBoard").transform.Find("Timer").Find("Text").gameObject;
			GameObject timer = GameObject.Find("ScoreBoard/Timer/Text");
			Timer timerVariable = timer.GetComponent<Timer>();
			if (timerVariable.currentTime <= limit)
			{
	            completed = true;
			}
        }
    }
}