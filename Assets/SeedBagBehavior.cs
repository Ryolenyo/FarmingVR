using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBagBehavior : MonoBehaviour
{
    public GameObject seed;
    private bool isSeedOut = true;
    private float spawnTime = 1;
    private float time = 0;
    private int numberOfSeed = 10;
    private int outSeed = 0;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSeedOut)
        {
            time += Time.deltaTime;
            if (time > spawnTime)
            {
                Instantiate(seed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity,gameObject.transform);
                time = 0;
                isSeedOut = false;
                outSeed++;
            }
        }
        if (outSeed  >= numberOfSeed)
        {
            Destroy(this);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Seed")
        {
            isSeedOut = true;
        }
    }
}
