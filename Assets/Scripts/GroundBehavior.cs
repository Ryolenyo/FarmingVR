using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    public bool isTouchedByStick;
    public bool isDug;
    public bool isWatered;
    public bool isFer;

    public bool isPlanted;
    public int seedType = 0; // 1 = mono , 2 = poly
    public GameObject type1;
    public GameObject type2;

    public Material gDig;
    public Material gWater;
    public Material gFer;
    public Material gWaterFer;

    // Start is called before the first frame update
    void Start()
    {
        isTouchedByStick = false;
        isDug = false;

        isPlanted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Normal Ground
        if (!isDug)
        {
            if (isTouchedByStick)
            {
                gameObject.GetComponent<Renderer>().material = gDig;
                isTouchedByStick = false;
                isDug = true;
                gameObject.tag = "DigGround";

            }
        }

        //Dug Ground
        if (isPlanted)
        {
            switch (seedType)
            {
                case 1:
                    Instantiate(type1, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(type2, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), Quaternion.identity);
                    break;
            }

            isPlanted = false;
        }

        //Watered Ground
        if (isWatered && !isFer)
        {

        }
        else if (isFer && isWatered)
        {

        }
        else if (isWatered && isFer)
        {

        }
    }
}
