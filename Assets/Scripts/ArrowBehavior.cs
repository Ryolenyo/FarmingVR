using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    private float startMeter;
    private float difMeter = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        startMeter = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startMeter - 0.1f)
        {
            difMeter = -difMeter;

        }
        else if (transform.position.y > startMeter + 0.1f)
        {
            difMeter = -difMeter;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + difMeter , transform.position.z);
        
    }
}
