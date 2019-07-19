using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBoard : MonoBehaviour
{
    private int money;
    [SerializeField] Text moneyText;

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

        moneyText.text = "Money: " + money.ToString();

    }
}
