using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject itemSpawner;
    public GameObject item;
    public int itemCost;

    private bool isGetItem;
    private bool isTimer;
    public float currentTime;
    private int coolDown;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = 2;
        isGetItem = true;
        isTimer = false;
}

    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
            currentTime += Time.deltaTime;
            if (currentTime > coolDown)
            {
                isGetItem = true;
                isTimer = false;
                currentTime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            GameObject player = GameObject.Find("Player");
            PlayerPocket playerVariable = player.GetComponent<PlayerPocket>();
            if (isGetItem)
            {
                if (playerVariable.money >= itemCost)
                {
                    playerVariable.money -= itemCost;
                    Instantiate(item, new Vector3(itemSpawner.transform.position.x, itemSpawner.transform.position.y + 0.5f, itemSpawner.transform.position.z), Quaternion.identity);
                }
                else
                {
                    //SHOW NOT ENOUGH MONEY
                }
                isTimer = true;
                isGetItem = false;
            }
        }
    }
}
