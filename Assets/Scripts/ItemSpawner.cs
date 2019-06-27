﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public void buyItem(int itemCost)
    {
        GameObject player = GameObject.Find("Player");
        PlayerPocket playerVariable = player.GetComponent<PlayerPocket>();
        if (playerVariable.money >= itemCost)
        {
            playerVariable.money -= itemCost;
        }
        else
        {
            //SHOW NOT ENOUGH MONEY
        }
    }

    public void spawnItem(GameObject item)
    {
        GameObject itemSpawner = GameObject.Find("itemShopSpawner");
        Instantiate(item, new Vector3(itemSpawner.transform.position.x, itemSpawner.transform.position.y + 0.5f, itemSpawner.transform.position.z), Quaternion.identity);
    }

}