using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizerBehavior : MonoBehaviour
{
    public int max;
    public GameObject fertilizerBag;
    public float minHeight;

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
        GroundBehavior groundVariable = ground.GetComponent<GroundBehavior>();
        //Fertilized groundQuality = ground.GetComponent<Fertilized>();

        if((ground.tag == "Planted" || ground.tag == "DigGround") && !groundVariable.isFertilized && max > 0 && fertilizerBag.transform.position.y > minHeight)
        {
            max--;
            groundVariable.isFertilized = true;
            //groundQuality.fertilized = true;
            Debug.Log("fertilizer remain: "+ max);
        }
    }
}
