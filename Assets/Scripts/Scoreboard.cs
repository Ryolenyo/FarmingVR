using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private int money;
    [SerializeField] Text score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerPocket playerVariable = player.GetComponent<PlayerPocket>();
        money = playerVariable.money;

        score.text = money.ToString();
    }
}
