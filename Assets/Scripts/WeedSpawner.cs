using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSpawner : MonoBehaviour
{
    public GameObject[] ground;
    public GameObject weed;
    public float spawnTime;
    public float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            int num = Random.Range(0,17);
            GameObject chooseGroud = ground[num];
            Instantiate(weed, 
                new Vector3 (chooseGroud.transform.position.x+0.25f, chooseGroud.transform.position.y+0.1f, chooseGroud.transform.position.z - 0.25f), 
                Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));

            currentTime = 0;
        }
    }
}
