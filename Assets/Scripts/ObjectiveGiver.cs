using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGiver : MonoBehaviour
{
    public Objective objective;
    public string[] requiredObject;

    // Start is called before the first frame update
    void Start()
    {
        objective.description = "collect 10 gold products";
        objective.type = ObjectiveType.Collecting;

        requiredObject = new string[] {"Gold"};

        objective.Init(10, requiredObject);
    }
}