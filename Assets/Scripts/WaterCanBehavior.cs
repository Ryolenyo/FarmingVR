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
        GameObject colObject = collider.gameObject;

        //Filling water can
        if (colObject.name == "Well")
        {
            if (currentVolume < maxVolume)
            {
                currentVolume = currentVolume + 1;
            }
            Debug.Log("filling : " + currentVolume);
        }

        //Spill
/*        else if (collider.gameObject.tag == "AllGround")
        {
            if (currentVolume > 0)
            {
                currentVolume = currentVolume - 1;
            }
            Debug.Log("spilling: " + currentVolume);
        }
*/
        //Watering plant
        else
        {
            if (currentVolume > 0)
            {
                //Watering
                currentVolume = currentVolume - 1;

                if (colObject.tag == "Sapling")
                {
                    PlantBehavior plantVariable = colObject.GetComponent<PlantBehavior>();
                    plantVariable.currentWater = plantVariable.currentWater + 1;
                }
                else if (colObject.tag == "Stalk")
                {
                    StalkBehavior stalkVariable = colObject.GetComponent<StalkBehavior>();
                    stalkVariable.currentWater = stalkVariable.currentWater + 1;

                }
                //Spilling
                else if (colObject.tag == "AllGround")
                {
                    //Debug.Log("spilling: " + currentVolume);
                }
            }
            //Debug.Log("watering: " + currentVolume);
        }
    }
}