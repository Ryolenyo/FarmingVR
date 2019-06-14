using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public int seedType;

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
        Debug.Log("Seed");
        if (collider.gameObject.tag == "DigGround")
        {
            GameObject digGround = collider.gameObject;
            ChangeObject groundVariable = digGround.GetComponent<ChangeObject>();
            groundVariable.isPlanted = true;
            groundVariable.seedType = seedType;

            digGround.tag = "Planted";

            Destroy(gameObject);
        }
    }
}