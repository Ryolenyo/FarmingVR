using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public bool isPlanted;
    public GameObject Sphere;

    // Start is called before the first frame update
    void Start()
    {
        isPlanted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            Instantiate(Sphere, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            isPlanted = false;
        }
    }
}
