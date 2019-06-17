using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMeter : MonoBehaviour
{
    public GameObject can;
    float preHeight = 0;
    public bool inc;
    public bool dec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaterCanBehavior canVariable = can.GetComponent<WaterCanBehavior>();
        if (preHeight < canVariable.currentVolume || inc)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.0004f, transform.position.z);
            preHeight = canVariable.currentVolume;
        }
        else if (preHeight > canVariable.currentVolume || dec)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.0004f, transform.position.z);
            preHeight = canVariable.currentVolume;
        }
    }
}
