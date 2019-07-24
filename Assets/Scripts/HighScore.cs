using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScore : MonoBehaviour
{
	public GameObject scoreBoard;
	
	private string path;
	private int score;
	[SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        path = "Assets/Resources/score.txt";
		if (!File.Exists(path))
		{
			File.WriteAllText(path, "0");
		}
		score = int.Parse(File.ReadAllText(path));
		Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
		Scoreboard currentScore = scoreBoard.GetComponent<Scoreboard>();

		if (currentScore.score > score)
		{
			score = currentScore.score;
			scoreText.text = "New High Score: " + score.ToString();
			File.WriteAllText(path, score.ToString());
		}
		else
		{
			scoreText.text = "High Score: " + score.ToString();
		}
    }
}
