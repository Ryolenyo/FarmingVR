using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehavior : MonoBehaviour
{
    private int totalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Plant")
        {
            GameObject plant = collider.gameObject;
            PlantBehavior plantVariable = plant.GetComponent<PlantBehavior>();
            GameObject player = GameObject.Find("Player");
            PlayerPocket playerVariable = player.GetComponent<PlayerPocket>();
            playerVariable.money += plantVariable.valuePlant;

            Debug.Log(playerVariable.money);

            Destroy(collider);
        }
    }
}
