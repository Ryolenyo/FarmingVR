using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictionCheck : MonoBehaviour
{
	public bool checker;
	public string[] name;
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
		if (checker)
		{
			foreach (string restricted in name)
			{
				GameObject temp = GameObject.Find(restricted);
				if (temp != null)
				{
					objectiveGiver.objective.goal.RestrictionFailed();
				}
			}
		}
    }
}