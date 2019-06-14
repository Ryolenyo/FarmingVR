using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public bool isPlanted;
    public GameObject ground;
    public GameObject plant;


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
            //Instantiate(ground, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
            Instantiate(plant, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
            isPlanted = false;
        }
    }
}
