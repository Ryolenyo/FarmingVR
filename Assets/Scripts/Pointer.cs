using System.Collections;
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
                if (sceneName == "Quit")
                {
                    Application.Quit();
                }
                else
                {
                    GameObject player = GameObject.Find("Player");
                    PlayerPocket playerVariable = player.GetComponent<PlayerPocket>();
                    Destroy(player);
                    Application.LoadLevel(sceneName);
                }
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
