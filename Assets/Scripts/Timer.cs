using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float startTime;

    private string textTime;

    private float guiTime;
    //The gui-Time is the difference between the actual time and the start time.
    private int minutes;
    private int seconds;
    private int fraction;

    public int lim;
	public GameObject objectiveBoard;
    public GameObject uiEnd;

	public GameObject basket;

    //Create a reference for the textfield

    public Text textField;

    // Use this for initialization
    void Start()
    {
        uiEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		guiTime = lim - Time.timeSinceLevelLoad;
        //The gui-Time is the difference between the actual time and the start time.
        minutes = (int)guiTime / 60; //Divide the guiTime by sixty to get the minutes.
        seconds = (int)guiTime % 60;//Use the euclidean division for the seconds.
        fraction = (int)(guiTime * 100) % 100;
        textTime = string.Format("{0:00}:{1:00}", minutes, seconds, fraction);
        //text.Time is the time that will be displayed.
        if (guiTime <= 0)
        {
			GameObject objective = GameObject.Find("Objective System/ObjectiveGiver");
			ObjectiveGiver objectiveGiver = objective.GetComponent<ObjectiveGiver>();
			if (objectiveGiver.objective.type == ObjectiveType.Restriction)
			{
				objectiveGiver.objective.goal.RestrictionCompleted();
			}

            textField.text = "TIMES UP";

            GameObject player = GameObject.Find("Player");
            PlayerPocket playerVariable = player.GetComponent<PlayerPocket>();
            playerVariable.pointerOn = true;

			objectiveBoard.SetActive(false);
            uiEnd.SetActive(true);

			Destroy(basket.GetComponent<BasketBehavior>());
        }
        else
        {
            textField.text = "Time: " + textTime;
        }


    }
}
