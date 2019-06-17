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
        Fertilized groundQuality = ground.GetComponent<Fertilized>();

        if((ground.tag == "Planted" || ground.tag == "DigGround") && !groundQuality.fertilized && max > 0 && fertilizerBag.transform.position.y > minHeight)
        {
            max--;
            groundQuality.fertilized = true;
            Debug.Log("fertilizer remain: "+ max);
        }
    }
}
