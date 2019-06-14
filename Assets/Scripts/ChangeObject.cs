using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public bool isPlanted;
    public int seedType = 0; // 1 = mono , 2 = poly
    public GameObject ground;
    public GameObject type1;
    public GameObject type2;


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
            switch(seedType){
                case 1:
                    Instantiate(type1, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(type2, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), Quaternion.identity);
                    break;
            } 
           
            isPlanted = false;
        }
    }
}
