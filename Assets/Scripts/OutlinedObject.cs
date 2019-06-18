using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinedObject : MonoBehaviour
{
    Shader standard;
    Shader outline;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        standard = Shader.Find("Standard");
        outline = Shader.Find("Outlined/UltimateOutline");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tools")
        {
            rend.material.shader = outline;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tools")
        {
            rend.material.shader = standard;
        }
    }
}
