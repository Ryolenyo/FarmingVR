using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR.InteractionSystem;

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

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
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
                isTimerRun = true;
                if(gameObject.tag == "Sapling")
                {
                    gameObject.tag = "Plant";
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            }
        }

        //GROWING PART
        if (isTimerRun)
        {
            timer(targetTime);
        }

        Throwable throwable = GetComponent<Throwable>();
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        if (throwable.attached)
        {
            isTimerRun = false;
            rigidbody.useGravity = true;
            //rigidbody.isKinematic = false;
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
            GameObject newObject;
            newObject = (GameObject)EditorUtility.InstantiatePrefab(nextObject);
            newObject.transform.position = transform.position;
            newObject.transform.rotation = transform.rotation;

            Destroy(gameObject);

        }

    }
}
