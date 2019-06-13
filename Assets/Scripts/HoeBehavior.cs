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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ground")
        {
            GameObject ground = collider.gameObject;
            SpawnObjectFromTouch groundVariable = ground.GetComponent<SpawnObjectFromTouch>();
            groundVariable.isTouchedByStick = true;
        }
    }
}
