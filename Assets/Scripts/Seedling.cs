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
                    //Debug.Log(groundVariable.transform.position.x+" "+ groundVariable.transform.position.y+ " "+ groundVariable.transform.position.z);
                    //Debug.Log(groundVariable.transform.localPosition.x + " " + groundVariable.transform.localPosition.y + " " + groundVariable.transform.localPosition.z);
                    GameObject sap = Instantiate(sapling, new Vector3(0, 0, 0), Quaternion.identity);
                    sap.transform.localPosition = new Vector3(groundVariable.transform.position.x + 0.25f, groundVariable.transform.position.y, groundVariable.transform.position.z - 0.25f);
                    break;
                case 2:
                    GameObject stalk = Instantiate(sapling, new Vector3(0, 0, 0), Quaternion.identity);
                    stalk.transform.localPosition = new Vector3(groundVariable.transform.position.x + 0.25f, groundVariable.transform.position.y - 0.1f, groundVariable.transform.position.z - 0.25f);
                    break;
            }

            Destroy(gameObject);
        }
    }
}