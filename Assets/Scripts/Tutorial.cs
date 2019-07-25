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
    public GameObject tutorPlant2;
    public GameObject tutorMole;
    public GameObject laser;
    public GameObject exit;

    public Transform spawnPoint;

    public int currentState = -1;

    public Text textField;
    private string tutorText = "Welcome to Tutorial";

    private bool isTimerRun = true;
    private float currentTime = 0;
    private bool stop = true;

    public GameObject[] arrowSet;

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
            arrowSet[0].SetActive(true);
        }
        else if (currentState == 1) // Buy item
        {
            shopUI.SetActive(true);
            tutorText = "Buy some seed by press the blue button ! and Plant the seed !";
            currentState = 2;
            arrowSet[1].SetActive(true);
            arrowSet[0].SetActive(false);
        }
        else if (currentState == 2) // plant
        {
            currentState = -1;

        }
        else if (currentState == 3) // fill , water
        {
            Instantiate(wateringCan, spawnPoint);
            tutorText = "Fill this watering can and water your plant !";
            currentTime = 0;
            currentState = -1;
            arrowSet[3].SetActive(true);
            arrowSet[1].SetActive(false);

        }
        else if (currentState == 4) // harvest , throw in basket
        {
            arrowSet[3].SetActive(false);
            tutorPlant.SetActive(true);
            tutorText = "This is all state of plant. Golden state is the most valuable plant !";
            isTimerRun = true;
        }
        else if (currentState == 5) // harvest , throw in basket
        {
            tutorPlant.SetActive(false);
            tutorText = "Harvest it and put in the basket !";
            arrowSet[5].SetActive(true);
            arrowSet[3].SetActive(false);
        }
        else if (currentState == 6) // mole
        {
            tutorMole.SetActive(true);
            tutorPlant2.SetActive(true);
            arrowSet[5].SetActive(false);
            arrowSet[6].SetActive(true);
            tutorText = "That Mole try to steal your product! Catch it! Throw it away!";
            
        }
        else if (currentState == 7) // mole
        {
            arrowSet[6].SetActive(false);
            Instantiate(net, spawnPoint);
            Instantiate(trapper, spawnPoint);
            tutorText = "But it will come back in every 30s. You have to use trapper or net !";
            currentState = 8;
            currentTime = 0;
            isTimerRun = true;
        }
        else if (currentState == 8)
        {
            
        }
        else if (currentState == 9)
        {
            tutorText = "Tutorial ends here.";
            laser.SetActive(true);
            exit.SetActive(true);
        }

        Debug.Log(currentState);

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
            if (stop)
            {
                currentState = 3;
                stop = false;
            }
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
