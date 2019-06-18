using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    public bool isTouchedByStick = false;
    public bool isDug = false;
    public bool isPlanted = false;
    public bool isWatered = false;
    public bool isFer = false;

    public bool isChange = true;
    public bool isStalk = false;
    public bool isStalkGrow = true;

    public int seedType = 0; // 1 = mono , 2 = poly
    public GameObject type1;
    public GameObject type2;

    public Material gNormal;
    public Material gDig;
    public Material gWater;
    public Material gFer;
    public Material gWaterFer;

    public float volume = 0;
    public float maxVolume = 50;
    public float consume = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Be called when plant is harvested
    void ResetGround()
    {
        isTouchedByStick = false;
        isDug = false;
        isPlanted = false;
        isWatered = false;
        isFer = false;
        isChange = true;
        volume = 0;

        gameObject.GetComponent<Renderer>().material = gNormal;

        gameObject.tag = "ground";
    }

    // Update is called once per frame
    void Update()
    {
        //Normal Ground
        if (!isDug)
        {
            if (isTouchedByStick)
            {
                gameObject.GetComponent<Renderer>().material = gDig;
                isTouchedByStick = false;
                isDug = true;
                gameObject.tag = "DigGround";
                Debug.Log("Hey");
            }
        }

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
        }

        //Check water volume
        if (isDug)
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
        }
    }

    void OnTriggerStay(Collider other)
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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plant" || other.tag == "Stalk")
        {
            ResetGround();
        }
    }
}
