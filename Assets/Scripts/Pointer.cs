﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Pointer : MonoBehaviour
{
    public float countDown = 3;
    public string sceneName;
    public Text textField;
    public string title;

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Laser")
        {
            countDown -= Time.deltaTime;
            textField.text = "" + ((int)countDown+1)%60;
            if (countDown < 0)
            {
                Application.LoadLevel(sceneName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Laser")
        {
            countDown = 3;
            textField.text = title;
        }
    }
}
