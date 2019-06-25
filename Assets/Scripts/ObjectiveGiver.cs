using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGiver : MonoBehaviour
{
    public Objective objective;
    private string[] objectiveDescription =
    {
        "Collect 10 crops during golden time",
        "Plant only monocarpic crops",
        "Get 1000 score without using fertilizer",
        "Get 500 within the first 2 minutes of the game",
        "Handle moles without using trapper or net",
    };
    private ObjectiveType[] objectiveType =
    {
        ObjectiveType.Collecting,
        ObjectiveType.Restriction,
        ObjectiveType.Restriction,
        ObjectiveType.Restriction,
        ObjectiveType.Restriction
    };

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 5);
        objective.description = objectiveDescription[num];
        objective.type.objectiveType = objectiveType[num];
    }
}