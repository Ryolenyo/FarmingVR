using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_WaterCanBehavior : MonoBehaviour
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

        //Watering ground
        else
        {
            if (currentVolume > 0)
            {
                currentVolume = currentVolume - 1;
                //Watering
                if (colObject.tag == "DigGround" || colObject.tag == "Planted")
                {
                    GroundBehavior groundVariable = colObject.GetComponent<GroundBehavior>();
                    groundVariable.volume = groundVariable.volume + 1;

                    if(groundVariable.volume > groundVariable.maxVolume)
                    {
                        groundVariable.isWatered = true;
                    }
                    //Debug.Log("watering: " + currentVolume);
                }
                else if (colObject.tag == "AllGround")
                {
                    //Debug.Log("spilling: " + currentVolume);
                }
            }
        }
    }
}
