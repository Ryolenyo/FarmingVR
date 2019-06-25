using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGiver : MonoBehaviour
{
    public Objective objective;
    public string[] objectiveTitle =
    {
        "Collect 10 crops during golden time",
        "Plant only monocarpic crops",
        "Get 1000 score without using fertilizer",
        "Get 500 within the first 2 minutes of the game",
        "Handle moles without using trapper",
    };

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 5);
        objective.title = objectiveTitle[num];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
