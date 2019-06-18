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
        fix_WaterCanBehavior canVariable = can.GetComponent<fix_WaterCanBehavior>();
        float currentHeight = canVariable.currentVolume;
        if (preHeight < currentHeight || inc)
        {
            float dif = (currentHeight - preHeight) / 2500;
            transform.Translate(0, dif, 0);
            preHeight = canVariable.currentVolume;
        }
        else if (preHeight > currentHeight || dec)
        {
            float dif = -(preHeight - currentHeight) / 2500;
            transform.Translate(0, dif, 0);
            preHeight = canVariable.currentVolume;
        }
    }
}
