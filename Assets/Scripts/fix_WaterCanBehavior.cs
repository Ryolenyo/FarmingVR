using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_WaterCanBehavior : MonoBehaviour
{
    public GameObject FillingSfx;
    public GameObject WateringSfx;

    public bool isFill = false;
    public bool isWat = false;

    public float currentVolume = 0;
    public float maxVolume = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFill && !isWat)
        {
            FillingSfx.SetActive(true);
            WateringSfx.SetActive(false);
        }
        else if (!isFill && isWat)
        {
            FillingSfx.SetActive(false);
            WateringSfx.SetActive(true);
        }
        else
        {
            FillingSfx.SetActive(false);
            WateringSfx.SetActive(false);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        GameObject colObject = collider.gameObject;

        //Filling water can
        if (colObject.name == "Well")
        {
            if (currentVolume < maxVolume)
            {
                currentVolume = currentVolume + 5;
                isFill = true;
                isWat = false;
            }
            else
            {
                isFill = false;
                isWat = false;
            }
            //Debug.Log("filling : " + currentVolume);

        }

        //Watering ground
        else
        {
            if (currentVolume > 0)
            {
                //Watering
                if (colObject.tag == "DigGround" || colObject.tag == "Planted")
                {
                    currentVolume = currentVolume - 1;
                    GroundBehavior groundVariable = colObject.GetComponent<GroundBehavior>();
                    groundVariable.volume = groundVariable.volume + 1;

                    if (groundVariable.volume > groundVariable.maxVolume)
                    {
                        groundVariable.isWatered = true;
                    }
                    //Debug.Log("watering: " + currentVolume);
                }
                else if (colObject.tag == "AllGround")
                {
                    currentVolume = currentVolume - 1;
                    //Debug.Log("spilling: " + currentVolume);
                }
                isFill = false;
                isWat = true;
            }
            else
            {
                isFill = false;
                isWat = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DigGround" || other.tag == "Planted" || other.tag == "AllGround")
        {
            isWat = false;
        }
    }
}
