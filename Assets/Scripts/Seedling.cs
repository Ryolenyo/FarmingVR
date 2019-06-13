using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{

    public GameObject Dirt;

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
        if (collider.gameObject.tag == "ground")
        {
            Debug.Log("d");
            GameObject blueCube = collider.gameObject;
            ChangeObject blueCubeVariable = blueCube.GetComponent<ChangeObject>();
            Destroy(Dirt);
            Destroy(gameObject);
            blueCubeVariable.isPlanted = true;
        }
    }
}