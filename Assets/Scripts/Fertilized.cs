using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilized : MonoBehaviour
{
    public GameObject plantDetection;

    public bool fertilized;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        fertilized = false;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fertilized && !done)
        {
            Instantiate(plantDetection, new Vector3(transform.position.x, transform.position.y+0.25f, transform.position.z), Quaternion.identity);
            done = true;
        }
    }
}