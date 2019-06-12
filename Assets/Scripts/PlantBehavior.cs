using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehavior : MonoBehaviour
{

    public bool isReady = false;
    public float currentWater = 0;
    public float maxWater = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWater > maxWater)
        {
            isReady = true;
        }

        if (isReady)
        {
            if (transform.position.y > 1)
            {
                isReady = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            }
        }
    }
}
