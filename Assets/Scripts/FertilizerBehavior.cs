using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizerBehavior : MonoBehaviour
{
    public int max = 10;
    public bool used;

    // Start is called before the first frame update
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(used)
        {
            max--;

            used = false;
        }
    }
}
