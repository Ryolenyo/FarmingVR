using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class StalkBehavior : MonoBehaviour
{
    //WATERING PART
    public bool isReady = false;
    public float currentWater = 0;
    public float maxWater = 50;
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
        //WATERTING PART
        if (currentWater > maxWater)
        {
            isReady = true;
        }

        if (isReady)
        {
            if (transform.position.y > 0.75)
            {
                isReady = false;
                PolyCarpicRespawn fruitVariable1 = fruitRespawn1.GetComponent<PolyCarpicRespawn>();
                PolyCarpicRespawn fruitVariable2 = fruitRespawn2.GetComponent<PolyCarpicRespawn>();
                PolyCarpicRespawn fruitVariable3 = fruitRespawn3.GetComponent<PolyCarpicRespawn>();
                fruitVariable1.isReady = true;
                fruitVariable2.isReady = true;
                fruitVariable3.isReady = true;

            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            }
        }
       

    }
}

