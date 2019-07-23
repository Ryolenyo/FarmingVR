using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject hoe;
    public GameObject wateringCan;
    public GameObject fertilizer;
    public GameObject shopUI;

    public Transform spawnPoint;

    public bool[] state;
    public int currentState;

    public Text textField;
    public string tutorText;

    // Start is called before the first frame update
    void Start()
    {

    }

    void activate(int currentState ,int number)
    {
        if (currentState == number)
        {
            state[currentState] = true;
        }
        else
        {
            state[currentState] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == 0) // Dig ground
        {
            Instantiate(hoe,spawnPoint);
        }
        else if (currentState == 1) // Buy item
        {

        }
        else if (currentState == 2) // fill water
        {

        }
        else if (currentState == 3) // water
        {

        }
        else if (currentState == 4) // harvest , throw in basket
        {

        }
        else if (currentState == 5) // fertilize
        {

        }
        else if (currentState == 6) // harvest , throw in basket
        {

        }
        else if (currentState == 7) // mole
        {

        }
    }
}
