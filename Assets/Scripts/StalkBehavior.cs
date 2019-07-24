using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StalkBehavior : MonoBehaviour
{
    public bool isReady = false;
    public bool stopGrow = false;
    public bool isFertilized = false;
	public bool isWeed = false;

    private float currentTime;
    public int spawnTime = 30;

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
                if (transform.position.y > 0.65f)
                {
                    stopGrow = true;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                }
            }

            //first time
            currentTime += Time.deltaTime;
            if (currentTime > spawnTime)
            {
                fruitVariable1.isReady = true;
                fruitVariable2.isReady = true;
                fruitVariable3.isReady = true;
            }
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

		if (isWeed)
		{
			fruitVariable1.isWeed = true;
			fruitVariable2.isWeed = true;
			fruitVariable3.isWeed = true;
		}
		else
		{
			fruitVariable1.isWeed = false;
			fruitVariable2.isWeed = false;
			fruitVariable3.isWeed = false;
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

			if (ground.isWeed)
			{
				isWeed = true;
			}
			else
			{
				isWeed = false;
			}
        }
    }
}

