using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlantBehavior : MonoBehaviour
{
    //WATERING PART
    public bool isReady = false;
    public float currentWater = 0;
    public float maxWater = 50;

    //GROWING PART
    public GameObject nextObject; // Next state of plant
    public float targetTime;
    public bool isTimerRun = false;
    public int valuePlant;

    //FERTILIZE PART
    public bool fertilized = false;

    //private GroundBehavior ground;
    private bool isPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //WATERTING PART

        /*
        if (currentWater > maxWater)
        {
            isReady = true;
        }
        */

        if (isReady)
        {
            if (transform.position.y > 0.75)
            {
                isReady = false;
                isTimerRun = true;
                if (gameObject.tag == "Sapling")
                {
                    gameObject.tag = "Plant";
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
            }
        }

        //GROWING PART
        if (isTimerRun)
        {
            timer(targetTime);
        }

        /*Throwable throwable = GetComponent<Throwable>();
        Collider collider = GetComponent<Collider>();
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        if (throwable.attached)
        {
            isTimerRun = false;
            rigidbody.useGravity = true;
            collider.isTrigger = false;
            ground.isReset = true;
        }*/
    }

    void timer(float time)
    {

        if (targetTime <= 0.0f)
        {
            isTimerRun = false;
            changeState();
        }
        else
        {
            targetTime -= Time.deltaTime;
        }

    }

    void changeState()
    {
        //Debug.Log("CHANGING...");

        targetTime = 3.0f;
        Instantiate(nextObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(gameObject);

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.tag == "Planted" || otherObject.tag == "SpawnPoint")
        {
            Collider collider = GetComponent<Collider>();
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            isTimerRun = false;
            rigidbody.useGravity = true;
            collider.isTrigger = false;

            if (otherObject.tag == "Planted" && !isPicked)
            {
                GroundBehavior ground = otherObject.GetComponent<GroundBehavior>();
                ground.isReset = true;
            }
            isPicked = true;
        }
    }
}