using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasketBehavior : MonoBehaviour
{
    public int score = 0;
    public bool objectiveChecker;
    private GameObject objective;
	private ObjectiveGiver objectiveGiver;
    public GameObject coin;

    public bool isTutor;

    // Start is called before the first frame update
    void Start()
    {
        if (!isTutor)
        {
            objective = GameObject.Find("Objective System/ObjectiveGiver");
            objectiveGiver = objective.GetComponent<ObjectiveGiver>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Plant")
        {
            GameObject plant = collider.gameObject;
            PlantBehavior plantVariable = plant.GetComponent<PlantBehavior>();
            GameObject player = GameObject.Find("Player");
            PlayerPocket playerVariable = player.GetComponent<PlayerPocket>();

            playerVariable.money += plantVariable.valuePlant;
            score += plantVariable.valuePlant;

            if (objectiveChecker)
            {
                GameObject plantState = plant.transform.GetChild(0).gameObject;
				if (objectiveGiver.objective.type == ObjectiveType.Collecting)
				{
	                objectiveGiver.objective.goal.CollectingCompleted(plantState.tag);
				}
				else
				{
					objectiveGiver.objective.goal.TimeLimitCompleted(plantState.tag);
				}
            }
            GameObject coinObject = Instantiate(coin,new Vector3 (collider.transform.position.x, collider.transform.position.y, collider.transform.position.z), Quaternion.Euler(90, 0, 90));
            MoneyBehavior moneyVariable = coinObject.GetComponent<MoneyBehavior>();
            moneyVariable.money = plantVariable.valuePlant;

            Destroy(collider.gameObject);
        }
    }
}