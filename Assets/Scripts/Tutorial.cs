using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject hoe;
    public GameObject wateringCan;
    public GameObject fertilizer;
    public GameObject net;
    public GameObject trapper;
    public GameObject shopUI;
    public GameObject tutorPlant;
    public GameObject tutorMole;

    public Transform spawnPoint;

    public bool[] state;
    public int currentState = 0;

    public Text textField;
    private string tutorText;

    private bool isTimerRun = false;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textField.text = tutorText;

        if (currentState == 0) // Dig ground
        {
            Instantiate(hoe,spawnPoint);
            tutorText = "Pick the hoe up and dig the ground !";
            currentState = -1;
        }
        else if (currentState == 1) // Buy item
        {
            shopUI.SetActive(true);
            tutorText = "Buy some seed by press the blue button !";
            currentState = 2;
        }
        else if (currentState == 2) // plant
        {
            tutorText = "Plant the seed !";
            currentState = -1;
        }
        else if (currentState == 3) // fill , water
        {
            Instantiate(wateringCan, spawnPoint);
            tutorText = "Fill this watering can and water your plant !";
            currentState = -1;
        }
        else if (currentState == 4) // harvest , throw in basket
        {
            tutorPlant.SetActive(true);
            tutorText = "This is all state of plant. Golden state is the most valuable plant !";
            isTimerRun = true;
        }
        else if (currentState == 5) // harvest , throw in basket
        {
            tutorPlant.SetActive(false);
            tutorText = "Harvest it and put in the basket !";
        }
        else if (currentState == 6) // mole
        {
            tutorMole.SetActive(true);
            tutorText = "That Mole try to steal your product! Catch it! Throw it away!";
        }
        else if (currentState == 7) // mole
        {
            Instantiate(net, spawnPoint);
            Instantiate(trapper, spawnPoint);
            tutorText = "But it will come back in every 30s. You have to use trapper or net !";
            currentState = -1;
        }

        //timer
        if (isTimerRun)
        {
            if (currentTime < 10)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                isTimerRun = false;
                currentState += 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hoe")
        {
            currentState = 1;
        }
        else if (other.tag == "Seed")
        {
            currentState = 3;
        }
        else if (other.tag == "Can")
        {
            currentState = 4;
        }
        else if (other.tag == "Coin")
        {
            currentState = 6;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mole")
        {
            currentState = 7;
        }
    }
}
