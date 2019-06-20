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

    public bool isReset;

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
            isFertile = true;
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
    }
}