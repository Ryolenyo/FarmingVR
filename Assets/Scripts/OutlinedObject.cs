using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinedObject : MonoBehaviour
{
    //public GameObject gameObject;
    Shader standard;
    Shader outline;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInParent<Renderer>();
        standard = Shader.Find("Legacy Shaders/Diffuse");
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
