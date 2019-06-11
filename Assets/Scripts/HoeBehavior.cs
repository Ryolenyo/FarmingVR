using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeBehavior : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BlueCube")
        {
            GameObject blueCube = GameObject.Find("BlueCube");
            SpawnObjectFromTouch blueCubeVariable = blueCube.GetComponent<SpawnObjectFromTouch>();
            blueCubeVariable.isTouchedByStick = true;
        }
    }
}
