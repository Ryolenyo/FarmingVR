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

	private int numCheck = 4;
	private int currentTime;

	AudioSource sound;

	private void Start()
	{
		sound = GetComponent<AudioSource>();
	}

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Laser")
        {
            countDown -= Time.deltaTime;
			currentTime = ((int)countDown+1)%60;
            textField.text = "" + currentTime;
			if (currentTime < numCheck)
			{
				numCheck = currentTime;
				sound.Play(0);
			}

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
					Destroy(GameObject.FindWithTag("Mole"));
					
					GameObject[] destroyList;
					
					destroyList = GameObject.FindGameObjectsWithTag("Destroy");
					foreach (GameObject destroyObj in destroyList)
					{
						Destroy(destroyObj);
					}

					destroyList = GameObject.FindGameObjectsWithTag("Seed");
					foreach (GameObject destroyObj in destroyList)
					{
						Destroy(destroyObj);
					}
					
					destroyList = GameObject.FindGameObjectsWithTag("Sapling");
					foreach (GameObject destroyObj in destroyList)
					{
						Destroy(destroyObj);
					}

					destroyList = GameObject.FindGameObjectsWithTag("Plant");
					foreach (GameObject destroyObj in destroyList)
					{
						Destroy(destroyObj);
					}

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
			numCheck = 4;
            textField.text = title;
        }
    }
}
