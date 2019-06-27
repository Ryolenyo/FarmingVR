using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior_ : MonoBehaviour
{
    public bool isDug;
    public bool isPlanted;
    public bool isWatered;
    public bool isDraining;
    public bool isFertilized;
    public bool isDeclining;
    public bool isFertile;

    public bool isReset;

    public GameObject[] ground;
    /* GROUND NUMBER
            Normal  =   0
            Dug     =   1
            Plant   =   2
            Water   =   3
            Fert    =   4
            Water + Fert = 5
    */

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

    void setGround(int numGround)
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == numGround)
            {
                ground[i].SetActive(true);
            }
            else
            {
                ground[i].SetActive(false);
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

        setGround(0); //Normal ground

        gameObject.tag = "ground";
    }

    // Update is called once per frame
    void Update()
    {
        //Normal Ground
        if (isDug)
        {
            setGround(1); //Dug ground
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
            setGround(5); //Water + Fer ground

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
            setGround(3); //Watered ground
            if (!isDraining)
            {
                volume -= maxVolume;
                isDraining = true;
            }
        }
        else if (!isWatered && isFertilized)
        {
            setGround(4); // Fertilized ground
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
            if (remainFertilizer > 0)
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