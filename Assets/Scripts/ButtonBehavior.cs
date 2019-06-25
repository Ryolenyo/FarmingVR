using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject itemSpawner;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            Instantiate(item,new Vector3 (itemSpawner.transform.position.x, itemSpawner.transform.position.y+0.5f, itemSpawner.transform.position.z),Quaternion.identity);
        }
    }
}
