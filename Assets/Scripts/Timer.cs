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

    //Create a reference for the textfield

    public Text textField;
    public string sceneNameToLoad;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        guiTime = Time.time - startTime;
        //The gui-Time is the difference between the actual time and the start time.
        minutes = (int)guiTime / 60; //Divide the guiTime by sixty to get the minutes.
        seconds = (int)guiTime % 60;//Use the euclidean division for the seconds.
        fraction = (int)(guiTime * 100) % 100;
        textTime = string.Format("{0:00}:{1:00}", minutes, seconds, fraction);
        //text.Time is the time that will be displayed.
        if (minutes >= 1)
        {
            textField.text = "TIMES UP";
            SceneManager.LoadScene(sceneNameToLoad);

        }
        else
        {
            textField.text = textTime;
        }


    }
}
