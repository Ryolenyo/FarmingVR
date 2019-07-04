using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGiver : MonoBehaviour
{
	public int n;
	public ObjectiveList list;

    public Objective objective;
    public string[] requiredObject;
	public int requiredAmount;
	public int time;

    // Start is called before the first frame update
    void Start()
    {
		n = Random.Range(0, list.size);
		
		objective.description = list.description[n];
        objective.type = list.type[n];
        //requiredObject[0] = list.requiredObject[n,0];
		/*for (int i = 0; i < list.requiredObject.GetLength(1); i++)
		{
			if (list.requiredObject[n, i] != null)
			{
				requiredObject[0] = list.requiredObject[n, 0];
			}
		}*/
		requiredAmount = list.requiredAmount[n];
		time = list.time[n];
        
		objective.Init(requiredAmount, requiredObject, time);

        /*objective.description = "collect 10 gold products";
        objective.type = ObjectiveType.Collecting;

        requiredObject = new string[] {"Gold"};

        objective.Init(10, requiredObject, 0);*/

		/*objective.description = "Sell 10 gold fruits in the first minute of the game";
        objective.type = ObjectiveType.TimeLimit;

        requiredObject = new string[] {"Gold"};

        objective.Init(10, requiredObject, 60);*/

		/*objective.description = "Test Restriction Type";
        objective.type = ObjectiveType.Restriction;

        requiredObject = new string[] {"OH"};

        objective.Init(0, requiredObject, 0);*/
    }

	void Update()
	{
		if (objective.goal.completed)
		{
			GameObject Basket = GameObject.Find("basketVoid");
			BasketBehavior basketVariable = Basket.GetComponent<BasketBehavior>();

			basketVariable.score += objective.rewardScore;
		}
	}
}