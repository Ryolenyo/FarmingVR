using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PolyCarpicRespawn : MonoBehaviour
{
    public bool isReady = false;
    public bool isGrowUp = true;
    public GameObject fruitObject;
    public float growUpTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            if (growUpTime <= 0.0f)
            {
                if (isGrowUp)
                {
                    GrowUp();
                }
            }
            else
            {
                growUpTime -= Time.deltaTime;
            }
        }        
        
    }

    void GrowUp()
    {
        Instantiate(fruitObject, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
        isGrowUp = false;
    }

    void OnTriggerExit(Collider collider)
    {
        growUpTime = 3.0f;
        isGrowUp = true;
    }

}
