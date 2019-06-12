using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectFromTouch : MonoBehaviour
{
    public bool isTouchedByStick;
    public GameObject Sphere;

    // Start is called before the first frame update
    void Start()
    {
        isTouchedByStick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchedByStick)
        {
            Debug.Log(transform.position.x);
            Instantiate(Sphere, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
            isTouchedByStick = false;
        }
    }
}
