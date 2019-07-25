using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public int score;
    [SerializeField] Text scoreText;
	[SerializeField] Text UIText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Basket = GameObject.Find("basketVoid");
        BasketBehavior basketVariable = Basket.GetComponent<BasketBehavior>();
		if (basketVariable)
		{
			score = basketVariable.score;
		}

        scoreText.text = "Score: " + score.ToString();
		UIText.text = score.ToString();
    }
}
