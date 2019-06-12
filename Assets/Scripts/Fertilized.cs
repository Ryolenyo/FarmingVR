using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilized : MonoBehaviour
{
    public int plantValue;
    public bool fertilized;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        fertilized = false;
        done = false;
        plantValue = Random.Range(5, 101);
    }

    // Update is called once per frame
    void Update()
    {
        if(fertilized && !done)
        {
            plantValue += 10 / 100;
            done = true;
        }
        Debug.Log("value: " + plantValue);
    }
}