using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private int score;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Basket = GameObject.Find("basketVoid");
        BasketBehavior basketVariable = Basket.GetComponent<BasketBehavior>();
        score = basketVariable.score;

        scoreText.text = score.ToString();

    }
}
