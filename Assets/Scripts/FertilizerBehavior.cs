using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizerBehavior : MonoBehaviour
{
    public int max = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject ground = other.gameObject;
        Fertilized groundQuality = ground.GetComponent<Fertilized>();
        if(ground.tag == "planted" && !groundQuality.fertilized && max > 0)
        {
            max--;
            groundQuality.fertilized = true;
        }
    }
}
