using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectFromTouch : MonoBehaviour
{
    public bool isTouchedByStick;
    public bool isDug;
    public GameObject DigGround;

    // Start is called before the first frame update
    void Start()
    {
        isTouchedByStick = false;
        isDug = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDug)
        {
            if (isTouchedByStick)
            {
                //Debug.Log(transform.position.x);
                Instantiate(DigGround, new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z), Quaternion.identity);
                isTouchedByStick = false;
                isDug = true;
            }
        }
    }
}
