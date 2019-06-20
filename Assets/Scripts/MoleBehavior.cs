﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{
    public bool isEat = false;
    public bool isGoUp = true;

    public float eatTime;
    public float escapeTime = 5;
    public float currentTime = 0;

    public GameObject[] target;
    public int randomGround = 0;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        eatTime = Random.Range(10.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEat)
        {
            //COUNT DOWN TO EAT
            if (currentTime > eatTime)
            {
                eatTime = Random.Range(10.0f, 30.0f);
                randomGround = Random.Range(0, 17);
                //GO TO TARGET POSITION
                currentTime = 0;
                transform.position = new Vector3(target[randomGround].transform.position.x, target[randomGround].transform.position.y-0.1f, target[randomGround].transform.position.z);
                isEat = false;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
        else
        {
            //GO UP          
            if (isGoUp)
            {
                if (transform.position.y < 0.5f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
                }
                else
                {
                    isGoUp = false;
                }
            }
            else
            {
                //EATING
                if (currentTime > escapeTime)
                {
                    //GoDown
                    if (transform.position.y > 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f, transform.position.z);
                    }
                    else
                    {
                        isEat = true;
                        isGoUp = true;
                        currentTime = 0;
                    }
                }
                else
                {
                    currentTime += Time.deltaTime;
                }
            }


        }
    }
 }
