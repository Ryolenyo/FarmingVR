using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanBehavior : MonoBehaviour
{
    public float currentVolume = 0;
    public float maxVolume = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider collider)
    {
        //Filling water can
        if (collider.gameObject.name == "Well")
        {
            if (currentVolume < maxVolume)
            {
                currentVolume = currentVolume + 1;
            }
            Debug.Log("filling : "+currentVolume);
        }

        //Watering plant
        if (collider.gameObject.tag == "Sapling")
        {
            //Call plant variable
            GameObject plant = collider.gameObject;
            PlantBehavior plantVariable = plant.GetComponent<PlantBehavior>();

            if (currentVolume > 0)
            {
                currentVolume = currentVolume - 1;
                plantVariable.currentWater = plantVariable.currentWater + 1;
            }
            Debug.Log("watering: "+currentVolume);
        }

        //Spill
        if (collider.gameObject.tag == "AllGround")
        {
            if (currentVolume > 0)
            {
                currentVolume = currentVolume - 1;
            }
            Debug.Log("spilling: " + currentVolume);
        }
    }
}
