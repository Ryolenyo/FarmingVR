using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StalkBehavior : MonoBehaviour
{
    //WATERING PART
    public bool isReady = false;
    public float currentWater = 0;
    public float maxWater = 50;

    public bool stopGrow = false;
    public bool isFertilized = false;

    public GameObject fruitRespawn1;
    public GameObject fruitRespawn2;
    public GameObject fruitRespawn3;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        PolyCarpicRespawn fruitVariable1 = fruitRespawn1.GetComponent<PolyCarpicRespawn>();
        PolyCarpicRespawn fruitVariable2 = fruitRespawn2.GetComponent<PolyCarpicRespawn>();
        PolyCarpicRespawn fruitVariable3 = fruitRespawn3.GetComponent<PolyCarpicRespawn>();

        if (isReady)
        {
            if (!stopGrow)
            {
                if (transform.position.y > 0.75)
                {
                    stopGrow = true;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                }
            }
            
            fruitVariable1.isReady = true;
            fruitVariable2.isReady = true;
            fruitVariable3.isReady = true;
        }
        else
        {
            fruitVariable1.isReady = false;
            fruitVariable2.isReady = false;
            fruitVariable3.isReady = false;
        }

        if (isFertilized)
        {
            fruitVariable1.isFertilized = true;
            fruitVariable2.isFertilized = true;
            fruitVariable3.isFertilized = true;
        }
        else
        {
            fruitVariable1.isFertilized = false;
            fruitVariable2.isFertilized = false;
            fruitVariable3.isFertilized = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.tag == "Planted")
        {
            GroundBehavior ground = otherObject.GetComponent<GroundBehavior>();
            if (ground.isWatered)
            {
                isReady = true;
                //ground.volume -= ground.maxVolume;
            }
            else
            {
                isReady = false;
            }

            if (ground.isFertilized)
            {
                isFertilized = true;
            }
            else
            {
                isFertilized = false;
            }
        }
    }
}

