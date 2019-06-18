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

    // Start is called before the first frame update
    void Start()
    {

    }

    void Reset()
    {
        isTouchedByStick = false;
        isDug = false;
        isPlanted = false;
        isWatered = false;
        isFer = false;
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
        if (volume > maxVolume)
        {
            isWatered = true;
        }
        else
        {
            isWatered = false;
        }


        //Watered Ground
        if (isWatered && !isFer)
        {
            gameObject.GetComponent<Renderer>().material = gWater;
        }
        else if (isFer && isWatered)
        {

        }
        else if (isWatered && isFer)
        {

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isWatered)
        {
            if (other.tag == "Sapling")
            {
                PlantBehavior plantVariable = other.GetComponent<PlantBehavior>();
                plantVariable.currentWater += 1;
            }
            else if (other.tag == "Stalk")
            {
                StalkBehavior stalkVariable = other.GetComponent<StalkBehavior>();
                stalkVariable.currentWater += 1;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plant")
        {
            Reset();
        }
    }
}
