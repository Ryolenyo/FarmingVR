using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    public int seedType;
    public GameObject sapling;

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
        if (collider.gameObject.tag == "DigGround")
        {
            GameObject digGround = collider.gameObject;
            GroundBehavior groundVariable = digGround.GetComponent<GroundBehavior>();
            groundVariable.isPlanted = true;

            switch (seedType)
            {
                case 1:
                    Instantiate(sapling, new Vector3(groundVariable.transform.position.x, groundVariable.transform.position.y + 0.1f, groundVariable.transform.position.z), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(sapling, new Vector3(groundVariable.transform.position.x, groundVariable.transform.position.y - 0.1f, groundVariable.transform.position.z), Quaternion.identity);
                    break;
            }

            Destroy(gameObject);
        }
    }
}