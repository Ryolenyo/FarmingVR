using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlantValue : MonoBehaviour
{
    public float targetTime;
    bool isTimerRun;

    // Start is called before the first frame update
    void Start()
    {
        isTimerRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimerRun)
        {
            timer(targetTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject plant = other.gameObject;
        if(plant.tag == "Plant")
        {
            PlantBehavior plantVariable = plant.GetComponent<PlantBehavior>();
            plantVariable.valuePlant += plantVariable.valuePlant * 10 / 100;
        }
    }

    void timer(float time)
    {

        if (targetTime <= 0.0f)
        {
            Destroy(gameObject);
        }
        else
        {
            targetTime -= Time.deltaTime;
        }

    }
}
