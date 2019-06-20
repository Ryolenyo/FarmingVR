using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    public bool isTouchedByStick;
    public bool isDug;
    public bool isPlanted;
    public bool isWatered;
    public bool isDraining;
    public bool isFertilized;
    public bool isDeclining;

    public bool isChange;
    public bool isStalk;
    public bool isGrow;

    public bool isReset;

    /*public int seedType = 0; // 1 = mono , 2 = poly
    public GameObject type1;
    public GameObject type2;
    */
    public Material gNormal;
    public Material gDug;
    public Material gWatered;
    public Material gFertilized;
    public Material gWateredFertilized;

    public float volume;
    public float maxVolume;
    public float remainFertilizer;

    // Start is called before the first frame update
    void Start()
    {
        isTouchedByStick = false;
        isDug = false;
        isPlanted = false;
        isWatered = false;
        isDraining = false;
        isFertilized = false;
        isDeclining = false;

        isChange = true;
        isStalk = false;
        isGrow = true;

        isReset = false;

        volume = 0;
        remainFertilizer = 0;
}

    //Be called when plant is harvested
    void ResetGround()
    {
        isTouchedByStick = false;
        isDug = false;
        isPlanted = false;
        isWatered = false;
        isDraining = false;
        isFertilized = false;
        isReset = false;
        isChange = true;
        volume = 0;

        gameObject.GetComponent<Renderer>().material = gNormal;

        gameObject.tag = "ground";
    }

    // Update is called once per frame
    void Update()
    {
        //Normal Ground
        if (isDug)
        {
            gameObject.GetComponent<Renderer>().material = gDug;
            isDug = false;
            gameObject.tag = "DigGround";
        }
        /*
        //Dug Ground
        if (isPlanted)
        {
            switch (seedType)
            {
                case 1:
                    Instantiate(type1, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(type2, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), Quaternion.identity);
                    break;
            }

            isPlanted = false;
        }*/

        if (isPlanted)
        {
            gameObject.tag = "Planted";
        }

        //Check water volume

        if (isWatered && isFertilized)
        {
            gameObject.GetComponent<Renderer>().material = gWateredFertilized;

            if (!isDraining)
            {
                volume -= maxVolume;
                isDraining = true;
            }

            if (!isDeclining)
            {
                remainFertilizer = 50;
                isDeclining = true;
            }
        }
        else if (isWatered && !isFertilized)
        {
            gameObject.GetComponent<Renderer>().material = gWatered;
            if (!isDraining)
            {
                volume -= maxVolume;
                isDraining = true;
            }
        }
        else if (!isWatered && isFertilized)
        {
            gameObject.GetComponent<Renderer>().material = gFertilized;
            if (!isDeclining)
            {
                remainFertilizer = 50;
                isDeclining = true;
            }
        }

        if (isDraining)
        {
            if (volume > 0)
            {
                volume -= 0.01f;
            }
            else
            {
                if (!isFertilized)
                {
                    isDug = true;
                }
                isDraining = false;
                isWatered = false;
            }
        }

        if (isDeclining)
        {
            if(remainFertilizer > 0)
            {
                remainFertilizer -= 0.01f;
            }
            else
            {
                if (!isWatered)
                {
                    isDug = true;
                }
                isDeclining = false;
                isFertilized = false;
            }


        }

        if (isReset)
        {
            ResetGround();
        }
        /*else if (isDug)
        {
            if (volume > maxVolume)
            {
                isWatered = true;
                isStalkGrow = true;
                if (isChange)
                {
                    gameObject.GetComponent<Renderer>().material = gWater;
                    isChange = false;
                }
            }
            else
            {
                if (!isChange)
                {
                    volume -= 0.01f; //plant consume water
                    if (volume <= 0)
                    {
                        gameObject.GetComponent<Renderer>().material = gDig;
                        isChange = true;
                        isStalkGrow = false;
                    }
                }
            }
        }*/
    }

    /*void OnTriggerStay(Collider other)
    {
        if (isWatered)
        {
            if (other.tag == "Sapling")
            {
                PlantBehavior plantVariable = other.GetComponent<PlantBehavior>();
                plantVariable.isReady = true;
                volume -= maxVolume;
                isWatered = false;
            }
            else if (other.tag == "Stalk")
            {
                StalkBehavior stalkVariable = other.GetComponent<StalkBehavior>();
                stalkVariable.isReady = true;
                volume -= maxVolume;
                isWatered = false;
                isStalk = true;

            }
        }

        if (isStalk)
        {
            if (!isStalkGrow)
            {
                StalkBehavior stalkVariable = other.GetComponent<StalkBehavior>();
                stalkVariable.isReady = false;
            }
        }
    }*/

    /*void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Plant")
        {
            ResetGround();
        }
    }*/
}
