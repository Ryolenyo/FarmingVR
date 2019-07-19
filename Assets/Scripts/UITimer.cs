using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITimer : MonoBehaviour
{
	public GameObject timer;

	public Text textField;

	private int lim;
	private int minutes;
	private int seconds;
	private	int fraction;
	private float guiTime;

	private string textTime;

    // Start is called before the first frame update
    void Start()
    {
		lim = timer.GetComponent<Timer>().lim;
    }

    // Update is called once per frame
    void Update()
    {
		guiTime = lim - Time.timeSinceLevelLoad;

		minutes = (int)guiTime / 60;
        seconds = (int)guiTime % 60;
        fraction = (int)(guiTime * 100) % 100;
        
		textTime = string.Format("{0:00}:{1:00}", minutes, seconds, fraction);
        
		if (guiTime <= 0)
		{
			textField.text = "TIMES UP";
		}
		else
		{
			textField.text = textTime;
		}
    }
}
