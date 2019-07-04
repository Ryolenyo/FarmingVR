using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AllGround")
        {
            Rigidbody weed = GetComponent<Rigidbody>();
            Collider weedCol = GetComponent<Collider>();
            weed.useGravity = true;
            weedCol.isTrigger = false;
        }
    }
}
