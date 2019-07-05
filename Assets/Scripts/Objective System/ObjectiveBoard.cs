using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveBoard : MonoBehaviour
{
	public Text objectiveText;
	private GameObject objective;
	private ObjectiveGiver objectiveGiver;

    // Start is called before the first frame update
    void Start()
    {
        objective = GameObject.Find("Objective System/ObjectiveGiver");
        objectiveGiver = objective.GetComponent<ObjectiveGiver>();
    }

    // Update is called once per frame
    void Update()
    {
        objectiveText.text = objectiveGiver.objective.description;
		if (objectiveGiver.objective.type != ObjectiveType.Restriction && !objectiveGiver.objective.goal.objectiveFailed)
		{
			objectiveText.text += " (" + objectiveGiver.objective.goal.currentAmount + "/" + objectiveGiver.objective.goal.requiredAmount + ")";
		}
		else if (objectiveGiver.objective.goal.objectiveFailed)
		{
			objectiveText.text += " (Failed)";
		}
		else if (objectiveGiver.objective.goal.completed)
		{
			objectiveText.text += " (Success!)";
		}
    }
}
