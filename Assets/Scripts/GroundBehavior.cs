using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    public bool isDug;
    public bool isPlanted;
    public bool isWatered;
    public bool isDraining;
    public bool isFertilized;
    public bool isDeclining;
    public bool isFertile;
    public bool isWeed;

    public bool isReset;

    public float volume;
    public float maxVolume;
    public float remainFertilizer;

    // Start is called before the first frame update
    void Start()
    {
        isDug = false;
        isPlanted = false;
        isWatered = false;
        isDraining = false;
        isFertilized = false;
        isDeclining = false;
        isFertile = false;

        isReset = false;

        volume = 0;
        remainFertilizer = 0;
    }

    void setGround(string ground)
    {
        foreach (Transform child in transform)
        {
            if (child.name == ground)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    //Be called when plant is harvested
    void ResetGround()
    {
        isDug = false;
        isPlanted = false;
        isWatered = false;
        isDraining = false;
        isFertilized = false;
        isDeclining = false;
        isFertile = false;

        isReset = false;

        volume = 0;
        remainFertilizer = 0;
        
        setGround("NormalGround");
        gameObject.tag = "ground";
    }

    // Update is called once per frame
    void Update()
    {
        //Normal Ground
        if (isDug)
        {
            setGround("DigGround");
            isDug = false;
            gameObject.tag = "DigGround";
        }

        if (isPlanted)
        {
            setGround("PlantGround_plant");
            isPlanted = false;
            gameObject.tag = "Planted";
        }

        //Check water volume

        if (isWatered && isFertilized)
        {
            if (gameObject.tag == "Planted")
            {
                setGround("PlantGround_water_fer");
            }
            else
            {
                setGround("DigGround_water_fer");
            }

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
            isFertile = true;
        }
        else if (isWatered && !isFertilized)
        {
            if (gameObject.tag == "Planted")
            {
                setGround("PlantGround_water");
            }
            else
            {
                setGround("DigGround_water");
            }

            if (!isDraining)
            {
                volume -= maxVolume;
                isDraining = true;
            }
        }
        else if (!isWatered && isFertilized)
        {
            if (gameObject.tag == "Planted")
            {
                setGround("PlantGround_fer");
            }
            else
            {
                setGround("DigGround_fer");
            }

            if (!isDeclining)
            {
                remainFertilizer = 50;
                isDeclining = true;
            }
            isFertile = true;
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
                    isPlanted = true;
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
                    isPlanted = true;
                }
                isDeclining = false;
                isFertilized = false;
            }


        }

        if (isReset)
        {
            ResetGround();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weed")
        {
            isWeed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weed")
        {
            isWeed = false;
        }
    }
}