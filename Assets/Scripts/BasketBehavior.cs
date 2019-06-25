using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehavior : MonoBehaviour
{
    public int score = 0;
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
            score += plantVariable.valuePlant;
            
            Destroy(collider.gameObject);
        }
    }
}
